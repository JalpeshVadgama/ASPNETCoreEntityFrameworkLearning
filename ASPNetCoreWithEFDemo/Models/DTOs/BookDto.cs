namespace ASPNetCoreWithEFDemo.Models.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = new List<string>();
    }

    public class CreateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public List<int> CategoryIds { get; set; } = new List<int>();
    }

    public class UpdateBookDto
    {
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
        public List<int> CategoryIds { get; set; } = new List<int>();
    }
}