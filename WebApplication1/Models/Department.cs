using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [MaxLength(255)]
        public string DepartmentName { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public int ManagerID { get; set; }

        // Навигационные свойства
        public virtual Employee Manager { get; set; } = null!;
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public virtual ICollection<DepartmentManager> DepartmentManagers { get; set; } = new List<DepartmentManager>();
        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; } = new List<WorkSchedule>();
    }
}
