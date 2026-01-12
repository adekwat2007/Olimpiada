using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EventStatus
    {
        [Key]
        public int StatusID { get; set; }

        [Required]
        [MaxLength(100)]
        public string StatusName { get; set; } = string.Empty;

        // Навигационные свойства
        public virtual ICollection<Event> Events { get; set; } = new List<Event>();
    }
}
