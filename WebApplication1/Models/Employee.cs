using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Employee
    {
        [Key]
        public int PersonalID { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public int DepartmentID { get; set; }

        [Required]
        public int PositionID { get; set; }

        public int? ManagerID { get; set; }

        [MaxLength(50)]
        public string? WorkPhone { get; set; }

        [MaxLength(50)]
        public string? MobilePhone { get; set; }

        [MaxLength(50)]
        public string? Office { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [MaxLength(255)]
        public string Password { get; set; } = string.Empty;

        public string? AdditionalInfo { get; set; }

        public int? AssistantID { get; set; }

        // Навигационные свойства
        public virtual Department Department { get; set; } = null!;
        public virtual Position Position { get; set; } = null!;
        public virtual Employee? Manager { get; set; }
        public virtual Employee? Assistant { get; set; }
        public virtual ICollection<Employee> ManagedEmployees { get; set; } = new List<Employee>();
        public virtual ICollection<Employee> AssistedEmployees { get; set; } = new List<Employee>();
        public virtual ICollection<Department> ManagedDepartments { get; set; } = new List<Department>();
        public virtual ICollection<DepartmentManager> DepartmentManagements { get; set; } = new List<DepartmentManager>();
        public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();
        public virtual ICollection<DayOffCalendar> DayOffs { get; set; } = new List<DayOffCalendar>();
        public virtual ICollection<TrainingCalendar> Trainings { get; set; } = new List<TrainingCalendar>();
        public virtual ICollection<VacationCalendar> Vacations { get; set; } = new List<VacationCalendar>();
        public virtual ICollection<MaterialAuthor> AuthoredMaterials { get; set; } = new List<MaterialAuthor>();
        public virtual ICollection<EventResponsible> ResponsibleEvents { get; set; } = new List<EventResponsible>();
    }
}
