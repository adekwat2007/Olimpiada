using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

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

        // Навигационные свойства
        public virtual EventStatus Status { get; set; } = null!;
        public virtual EventType EventType { get; set; } = null!;
        public virtual ICollection<EventResponsible> EventResponsibles { get; set; } = new List<EventResponsible>();
    }
}
