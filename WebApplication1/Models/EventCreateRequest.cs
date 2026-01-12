using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EventCreateRequest
    {
        [Required]
        [MaxLength(255)]
        public string EventName { get; set; } = string.Empty;

        [Required]
        public int StatusID { get; set; }

        [Required]
        public int EventTypeID { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public string? ShortDescription { get; set; }

        public List<int> ResponsibleEmployeeIds { get; set; } = new List<int>();
    }
}
