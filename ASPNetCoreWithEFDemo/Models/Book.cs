namespace ASPNetCoreWithEFDemo.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
        
        // Navigation properties
        public virtual Author Author { get; set; } = null!;
        public virtual ICollection<BookCategory> BookCategories { get; set; } = new List<BookCategory>();
    }
}