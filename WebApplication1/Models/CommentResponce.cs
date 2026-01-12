// Models/CommentResponse.cs
namespace WebApplication1.Models
{
    public class CommentResponse
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string Text { get; set; } = string.Empty;
        public string DateCreated { get; set; } = string.Empty;
        public string DateUpdated { get; set; } = string.Empty;
        public AuthorInfo Author { get; set; } = null!;
    }
}