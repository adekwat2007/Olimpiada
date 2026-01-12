// Models/UserLoginRequest.cs

// Models/DocumentResponse.cs
namespace WebApplication1.Models
{
    public class DocumentResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string DateCreated { get; set; } = string.Empty;
        public string DateUpdated { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool HasComments { get; set; }
        public AuthorInfo Author { get; set; } = null!;
    }
}
