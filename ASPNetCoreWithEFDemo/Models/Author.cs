namespace ASPNetCoreWithEFDemo.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        
        // Navigation property
        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}