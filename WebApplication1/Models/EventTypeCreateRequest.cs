using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EventTypeCreateRequest
    {
        [Required]
        [MaxLength(100)]
        public string EventTypeName { get; set; } = string.Empty;
    }
}
