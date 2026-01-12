using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DayOffRequest
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [MaxLength(500)]
        public string Reason { get; set; } = string.Empty;

        [Required]
        public int EmployeeID { get; set; }
    }
}
