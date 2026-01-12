using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class WorkScheduleRequest
    {
        [Required]
        public int DepartmentID { get; set; }

        public int? TrainingCalendarID { get; set; }

        public int? WorkCalendarID { get; set; }
    }
}
