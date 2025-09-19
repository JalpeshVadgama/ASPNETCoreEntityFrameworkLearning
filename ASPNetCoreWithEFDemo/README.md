# ASP.NET Core MVC with Entity Framework Core 9 Demo

This application demonstrates key Entity Framework Core 9 features through a comprehensive Books Library MVC application with full CRUD operations.

## Features Demonstrated

### 1. **Joins**
- **Inner Joins**: Books with Authors (`Include(b => b.Author)`)
- **Multiple Joins**: Books with Authors and Categories through BookCategories junction table
- **Complex Joins**: Search functionality with filtering across related entities
- **ThenInclude**: Nested includes for many-to-many relationships

### 2. **AsNoTracking**
- Used in all read-only operations for better performance
- Prevents EF from tracking entities in the change tracker
- Examples in `GetBooks()`, `GetBook()`, `SearchBooks()` methods

### 3. **Split Query**
- **AsSplitQuery()**: Splits complex queries with multiple includes into separate SQL queries
- Improves performance when loading related data
- Used in methods that include multiple navigation properties

### 4. **SingleOrDefault / FirstOrDefault**
- **SingleOrDefaultAsync()**: Used when expecting exactly one result or null
- **FirstOrDefaultAsync()**: Used when expecting the first result from a potentially larger set
- Proper error handling for not found scenarios

## MVC Pages and Actions

### Books Controller (`/Books`)

| Action | Route | EF Features | Description |
|--------|-------|-------------|-------------|
| Index | `/Books` | Joins, AsNoTracking, Split Query | List all books with author and category info |
| Details | `/Books/Details/{id}` | SingleOrDefault, AsNoTracking, Joins | View specific book details |
| FirstByAuthor | `/Books/FirstByAuthor/{authorId}` | FirstOrDefault, Joins | Get first book by author |
| Search | `/Books/Search` | Complex Joins, AsNoTracking | Search books with filters |
| Statistics | `/Books/Statistics` | Aggregations, Joins | View book statistics by author |
| Create | `/Books/Create` | Create with relationships | Create new book with categories |
| Edit | `/Books/Edit/{id}` | Update with relationships | Edit book and its categories |
| Delete | `/Books/Delete/{id}` | Delete with relationships | Delete book and related data |

### Authors Controller (`/Authors`)

| Action | Route | EF Features | Description |
|--------|-------|-------------|-------------|
| Index | `/Authors` | AsNoTracking | List all authors |
| Create | `/Authors/Create` | Basic Create | Add new author |

### Categories Controller (`/Categories`)

| Action | Route | EF Features | Description |
|--------|-------|-------------|-------------|
| Index | `/Categories` | AsNoTracking | List all categories |
| Create | `/Categories/Create` | Basic Create | Add new category |

## Database Schema

```
Authors (1) -----> (Many) Books (Many) -----> (Many) BookCategories (Many) -----> (1) Categories
```

- **Authors**: Author information
- **Books**: Book details with AuthorId foreign key
- **Categories**: Book categories
- **BookCategories**: Junction table for many-to-many relationship

## Getting Started

1. **Install Dependencies**:
   ```bash
   dotnet restore
   ```

2. **Update Connection String** (if needed):
   Edit `appsettings.json` to match your SQL Server instance.

3. **Run the Application**:
   ```bash
   dotnet run
   ```

4. **Use the Application**:
   - Navigate to the home page for an overview
   - Use the navigation menu to access Books, Authors, Categories, and Statistics
   - Database will be created and seeded automatically with sample data

## Code Examples

### AsNoTracking with Joins
```csharp
var books = await _context.Books
    .AsNoTracking() // No tracking for read-only
    .Include(b => b.Author) // Join with Authors
    .Include(b => b.BookCategories)
        .ThenInclude(bc => bc.Category) // Join with Categories
    .ToListAsync();
```

### Split Query for Performance
```csharp
var books = await _context.Books
    .AsNoTracking()
    .AsSplitQuery() // Split into multiple queries
    .Include(b => b.Author)
    .Include(b => b.BookCategories)
        .ThenInclude(bc => bc.Category)
    .ToListAsync();
```

### SingleOrDefault Usage
```csharp
var book = await _context.Books
    .AsNoTracking()
    .Include(b => b.Author)
    .SingleOrDefaultAsync(b => b.Id == id); // Exactly one or null
```

### FirstOrDefault Usage
```csharp
var book = await _context.Books
    .AsNoTracking()
    .Where(b => b.AuthorId == authorId)
    .OrderBy(b => b.PublishedDate)
    .FirstOrDefaultAsync(); // First match or null
```

## Sample Data

The application automatically seeds sample data:
- 3 Authors (J.K. Rowling, Stephen King, Agatha Christie)
- 4 Categories (Fantasy, Horror, Mystery, Young Adult)
- 3 Books with category relationships

## Navigation

- **Home** - Overview of EF Core 9 features and application structure
- **Books** - Full CRUD operations demonstrating all EF Core 9 features
- **Authors** - Manage book authors
- **Categories** - Manage book categories  
- **Statistics** - Complex aggregations and analytics

Each page includes detailed information about which EF Core 9 features are being demonstrated.