using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class WorkSchedule
    {
        [Key]
        public int ScheduleID { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        public int? TrainingCalendarID { get; set; }

        public int? WorkCalendarID { get; set; }

        // Навигационные свойства
        public virtual Department Department { get; set; } = null!;
        public virtual TrainingCalendar? TrainingCalendar { get; set; }
        public virtual WorkCalendar? WorkCalendar { get; set; }
    }
}
