using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class WorkCalendar
    {
        [Key]
        public int DayID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool IsWorkDay { get; set; }

        // Навигационные свойства
        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
    }
}
