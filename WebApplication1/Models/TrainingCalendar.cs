using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class TrainingCalendar
    {
        [Key]
        public int TrainingID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        // Навигационные свойства
        public virtual Employee Employee { get; set; } = null!;
        public virtual ICollection<TrainingMaterial> TrainingMaterials { get; set; } = new List<TrainingMaterial>();
        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
    }
}
