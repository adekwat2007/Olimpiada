using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EmployeeCreateRequest
    {
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
        public string Email { get; set; } = string.Empty;

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public string Password { get; set; } = string.Empty;

        public string? AdditionalInfo { get; set; }

        public int? AssistantID { get; set; }
    }
}
