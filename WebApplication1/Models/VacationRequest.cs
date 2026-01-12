using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class VacationRequest
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int EmployeeID { get; set; }
    }
}
