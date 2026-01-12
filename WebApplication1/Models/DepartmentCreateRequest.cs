using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DepartmentCreateRequest
    {
        [Required]
        [MaxLength(255)]
        public string DepartmentName { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public int ManagerID { get; set; }
    }
}
