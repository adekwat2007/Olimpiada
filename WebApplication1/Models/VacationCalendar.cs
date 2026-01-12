using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class VacationCalendar
    {
        [Key]
        public int VacationID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        // Навигационные свойства
        public virtual Employee Employee { get; set; } = null!;
    }
}
