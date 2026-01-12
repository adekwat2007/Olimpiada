using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Position
    {
        [Key]
        public int PositionID { get; set; }

        [Required]
        [MaxLength(255)]
        public string PositionName { get; set; } = string.Empty;

        [Required]
        public decimal Salary { get; set; }

        // Навигационные свойства
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
