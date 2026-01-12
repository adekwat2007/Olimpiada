// Models/UserLoginRequest.cs

// Models/DocumentResponse.cs

// Models/CommentResponse.cs (уже есть, но добавьте CreateRequest)
namespace WebApplication1.Models
{
    public class CommentCreateRequest
    {
        public string Text { get; set; } = string.Empty;
    }
}
