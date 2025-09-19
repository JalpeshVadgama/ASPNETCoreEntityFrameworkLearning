using ASPNetCoreWithEFDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreWithEFDemo.Services
{
    public static class DataSeeder
    {
        public static async Task SeedDataAsync(LibraryContext context)
        {
            // Ensure database is created
            await context.Database.EnsureCreatedAsync();

            // Check if data already exists
            if (await context.Authors.AnyAsync())
            {
                return; // Data already seeded
            }

            // Seed Authors
            var authors = new List<Author>
            {
                new Author { Name = "J.K. Rowling", Email = "jk@example.com", CreatedDate = DateTime.UtcNow },
                new Author { Name = "Stephen King", Email = "sk@example.com", CreatedDate = DateTime.UtcNow },
                new Author { Name = "Agatha Christie", Email = "ac@example.com", CreatedDate = DateTime.UtcNow }
            };

            context.Authors.AddRange(authors);
            await context.SaveChangesAsync();

            // Seed Categories
            var categories = new List<Category>
            {
                new Category { Name = "Fantasy", Description = "Fantasy novels and stories" },
                new Category { Name = "Horror", Description = "Horror and thriller books" },
                new Category { Name = "Mystery", Description = "Mystery and detective stories" },
                new Category { Name = "Young Adult", Description = "Books for young adults" }
            };

            context.Categories.AddRange(categories);
            await context.SaveChangesAsync();

            // Seed Books
            var books = new List<Book>
            {
                new Book 
                { 
                    Title = "Harry Potter and the Philosopher's Stone", 
                    ISBN = "978-0747532699", 
                    Price = 15.99m, 
                    PublishedDate = new DateTime(1997, 6, 26),
                    AuthorId = authors[0].Id
                },
                new Book 
                { 
                    Title = "The Shining", 
                    ISBN = "978-0307743657", 
                    Price = 12.99m, 
                    PublishedDate = new DateTime(1977, 1, 28),
                    AuthorId = authors[1].Id
                },
                new Book 
                { 
                    Title = "Murder on the Orient Express", 
                    ISBN = "978-0062693662", 
                    Price = 13.99m, 
                    PublishedDate = new DateTime(1934, 1, 1),
                    AuthorId = authors[2].Id
                }
            };

            context.Books.AddRange(books);
            await context.SaveChangesAsync();

            // Seed BookCategories (Many-to-many relationships)
            var bookCategories = new List<BookCategory>
            {
                new BookCategory { BookId = books[0].Id, CategoryId = categories[0].Id }, // Harry Potter - Fantasy
                new BookCategory { BookId = books[0].Id, CategoryId = categories[3].Id }, // Harry Potter - Young Adult
                new BookCategory { BookId = books[1].Id, CategoryId = categories[1].Id }, // The Shining - Horror
                new BookCategory { BookId = books[2].Id, CategoryId = categories[2].Id }  // Murder on Orient Express - Mystery
            };

            context.BookCategories.AddRange(bookCategories);
            await context.SaveChangesAsync();
        }
    }
}