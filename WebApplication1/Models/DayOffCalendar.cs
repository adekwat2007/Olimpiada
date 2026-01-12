using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DayOffCalendar
    {
        [Key]
        public int DayOffID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Reason { get; set; } = string.Empty;

        // Навигационные свойства
        public virtual Employee Employee { get; set; } = null!;
    }
}
