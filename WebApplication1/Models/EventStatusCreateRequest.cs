using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EventStatusCreateRequest
    {
        [Required]
        [MaxLength(100)]
        public string StatusName { get; set; } = string.Empty;
    }
}
