using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DepartmentManager
    {
        [Required]
        public int DepartmentID { get; set; }

        [Required]
        public int ManagerID { get; set; }

        // Навигационные свойства
        public virtual Department Department { get; set; } = null!;
        public virtual Employee Manager { get; set; } = null!;
    }
}
