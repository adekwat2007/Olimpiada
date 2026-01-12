// Models/ErrorResponse.cs
namespace WebApplication1.Models
{
    public class ErrorResponse
    {
        public long Timestamp { get; set; }
        public string Message { get; set; } = string.Empty;
        public string ErrorCode { get; set; } = string.Empty;

        public ErrorResponse(string message, string errorCode)
        {
            Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            Message = message;
            ErrorCode = errorCode;
        }
    }
}