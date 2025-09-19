using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNetCoreWithEFDemo.Models;
using ASPNetCoreWithEFDemo.Models.DTOs;

namespace ASPNetCoreWithEFDemo.Controllers
{
    public class BooksController : Controller
    {
        private readonly LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Books
        // Demonstrates: Joins, AsNoTracking, Split Query
        public async Task<IActionResult> Index()
        {
            var books = await _context.Books
                .AsNoTracking() // EF Core feature: No tracking for read-only operations
                .AsSplitQuery() // EF Core feature: Split query for better performance with includes
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    Price = b.Price,
                    PublishedDate = b.PublishedDate,
                    AuthorName = b.Author.Name, // Join with Author
                    Categories = b.BookCategories.Select(bc => bc.Category.Name).ToList() // Join with Categories
                })
                .ToListAsync();

            return View(books);
        }

        // GET: Books/Details/5
        // Demonstrates: SingleOrDefault, AsNoTracking, Joins
        public async Task<IActionResult> Details(int id)
        {
            var book = await _context.Books
                .AsNoTracking() // No tracking for read-only operation
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .Where(b => b.Id == id)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    Price = b.Price,
                    PublishedDate = b.PublishedDate,
                    AuthorName = b.Author.Name,
                    Categories = b.BookCategories.Select(bc => bc.Category.Name).ToList()
                })
                .SingleOrDefaultAsync(); // EF Core feature: SingleOrDefault

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/FirstByAuthor/5
        // Demonstrates: FirstOrDefault, Joins, AsNoTracking
        public async Task<IActionResult> FirstByAuthor(int authorId)
        {
            var book = await _context.Books
                .AsNoTracking()
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .Where(b => b.AuthorId == authorId)
                .OrderBy(b => b.PublishedDate)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    Price = b.Price,
                    PublishedDate = b.PublishedDate,
                    AuthorName = b.Author.Name,
                    Categories = b.BookCategories.Select(bc => bc.Category.Name).ToList()
                })
                .FirstOrDefaultAsync(); // EF Core feature: FirstOrDefault

            if (book == null)
            {
                ViewBag.Message = $"No books found for author with ID {authorId}.";
                return View("NotFound");
            }

            return View("Details", book);
        }

        // GET: Books/Search
        // Demonstrates: Complex joins, AsNoTracking, Split Query
        public async Task<IActionResult> Search(string? title = null, string? authorName = null, string? categoryName = null)
        {
            var query = _context.Books
                .AsNoTracking()
                .AsSplitQuery()
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .AsQueryable();

            // Dynamic filtering with joins
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(b => b.Title.Contains(title));
            }

            if (!string.IsNullOrEmpty(authorName))
            {
                query = query.Where(b => b.Author.Name.Contains(authorName));
            }

            if (!string.IsNullOrEmpty(categoryName))
            {
                query = query.Where(b => b.BookCategories.Any(bc => bc.Category.Name.Contains(categoryName)));
            }

            var books = await query
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    Price = b.Price,
                    PublishedDate = b.PublishedDate,
                    AuthorName = b.Author.Name,
                    Categories = b.BookCategories.Select(bc => bc.Category.Name).ToList()
                })
                .ToListAsync();

            ViewBag.Title = title;
            ViewBag.AuthorName = authorName;
            ViewBag.CategoryName = categoryName;

            return View("Index", books);
        } 
        // GET: Books/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Authors = await _context.Authors.AsNoTracking().ToListAsync();
            ViewBag.Categories = await _context.Categories.AsNoTracking().ToListAsync();
            return View();
        }

        // POST: Books/Create
        // Demonstrates: Create operation with related entities
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookDto createBookDto)
        {
            // Validate author exists using SingleOrDefaultAsync
            var author = await _context.Authors
                .AsNoTracking()
                .SingleOrDefaultAsync(a => a.Id == createBookDto.AuthorId);

            if (author == null)
            {
                ModelState.AddModelError("AuthorId", $"Author with ID {createBookDto.AuthorId} not found.");
                ViewBag.Authors = await _context.Authors.AsNoTracking().ToListAsync();
                ViewBag.Categories = await _context.Categories.AsNoTracking().ToListAsync();
                return View(createBookDto);
            }

            // Validate categories exist
            var categories = await _context.Categories
                .AsNoTracking()
                .Where(c => createBookDto.CategoryIds.Contains(c.Id))
                .ToListAsync();

            if (categories.Count != createBookDto.CategoryIds.Count)
            {
                ModelState.AddModelError("CategoryIds", "One or more category IDs are invalid.");
                ViewBag.Authors = await _context.Authors.AsNoTracking().ToListAsync();
                ViewBag.Categories = await _context.Categories.AsNoTracking().ToListAsync();
                return View(createBookDto);
            }

            var book = new Book
            {
                Title = createBookDto.Title,
                ISBN = createBookDto.ISBN,
                Price = createBookDto.Price,
                PublishedDate = createBookDto.PublishedDate,
                AuthorId = createBookDto.AuthorId
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            // Add book categories
            foreach (var categoryId in createBookDto.CategoryIds)
            {
                _context.BookCategories.Add(new BookCategory
                {
                    BookId = book.Id,
                    CategoryId = categoryId
                });
            }

            await _context.SaveChangesAsync();

            // Return the created book with joins
            var createdBook = await _context.Books
                .AsNoTracking()
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .Where(b => b.Id == book.Id)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    Price = b.Price,
                    PublishedDate = b.PublishedDate,
                    AuthorName = b.Author.Name,
                    Categories = b.BookCategories.Select(bc => bc.Category.Name).ToList()
                })
                .SingleAsync();

            return RedirectToAction(nameof(Details), new { id = book.Id });
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _context.Books
                .AsNoTracking()
                .Include(b => b.BookCategories)
                .SingleOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var updateBookDto = new UpdateBookDto
            {
                Title = book.Title,
                ISBN = book.ISBN,
                Price = book.Price,
                PublishedDate = book.PublishedDate,
                AuthorId = book.AuthorId,
                CategoryIds = book.BookCategories.Select(bc => bc.CategoryId).ToList()
            };

            ViewBag.Authors = await _context.Authors.AsNoTracking().ToListAsync();
            ViewBag.Categories = await _context.Categories.AsNoTracking().ToListAsync();
            ViewBag.BookId = id;

            return View(updateBookDto);
        }

        // POST: Books/Edit/5
        // Demonstrates: Update operation with related entities, SingleOrDefaultAsync
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UpdateBookDto updateBookDto)
        {
                var book = await _context.Books
                .Include(b => b.BookCategories)
                .SingleOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            // Validate author exists
            var author = await _context.Authors
                .AsNoTracking()
                .SingleOrDefaultAsync(a => a.Id == updateBookDto.AuthorId);

            if (author == null)
            {
                ModelState.AddModelError("AuthorId", $"Author with ID {updateBookDto.AuthorId} not found.");
                ViewBag.Authors = await _context.Authors.AsNoTracking().ToListAsync();
                ViewBag.Categories = await _context.Categories.AsNoTracking().ToListAsync();
                ViewBag.BookId = id;
                return View(updateBookDto);
            }

            // Validate categories exist
            var categories = await _context.Categories
                .AsNoTracking()
                .Where(c => updateBookDto.CategoryIds.Contains(c.Id))
                .ToListAsync();

            if (categories.Count != updateBookDto.CategoryIds.Count)
            {
                ModelState.AddModelError("CategoryIds", "One or more category IDs are invalid.");
                ViewBag.Authors = await _context.Authors.AsNoTracking().ToListAsync();
                ViewBag.Categories = await _context.Categories.AsNoTracking().ToListAsync();
                ViewBag.BookId = id;
                return View(updateBookDto);
            }

            // Update book properties
            book.Title = updateBookDto.Title;
            book.ISBN = updateBookDto.ISBN;
            book.Price = updateBookDto.Price;
            book.PublishedDate = updateBookDto.PublishedDate;
            book.AuthorId = updateBookDto.AuthorId;

            // Remove existing categories
            _context.BookCategories.RemoveRange(book.BookCategories);

            // Add new categories
            foreach (var categoryId in updateBookDto.CategoryIds)
            {
                book.BookCategories.Add(new BookCategory
                {
                    BookId = book.Id,
                    CategoryId = categoryId
                });
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Details), new { id = book.Id });
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books
                .AsNoTracking()
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .Where(b => b.Id == id)
                .Select(b => new BookDto
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    Price = b.Price,
                    PublishedDate = b.PublishedDate,
                    AuthorName = b.Author.Name,
                    Categories = b.BookCategories.Select(bc => bc.Category.Name).ToList()
                })
                .SingleOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        // Demonstrates: Delete operation, SingleOrDefaultAsync
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books
                .Include(b => b.BookCategories)
                .SingleOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            // Remove related BookCategories first
            _context.BookCategories.RemoveRange(book.BookCategories);
            
            // Remove the book
            _context.Books.Remove(book);
            
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Statistics
        // Demonstrates: Complex joins, aggregations, AsNoTracking
        public async Task<IActionResult> Statistics()
        {
            var stats = await _context.Books
                .AsNoTracking()
                .AsSplitQuery()
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .GroupBy(b => b.Author.Name)
                .Select(g => new
                {
                    AuthorName = g.Key,
                    BookCount = g.Count(),
                    AveragePrice = g.Average(b => b.Price),
                    TotalCategories = g.SelectMany(b => b.BookCategories).Select(bc => bc.CategoryId).Distinct().Count()
                })
                .ToListAsync();

            return View(stats);
        }
    }
}