using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EventType
    {
        [Key]
        public int EventTypeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string EventTypeName { get; set; } = string.Empty;

        // Навигационные свойства
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
