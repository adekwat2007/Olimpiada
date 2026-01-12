using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class PositionCreateRequest
    {
        [Required]
        [MaxLength(255)]
        public string PositionName { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}
