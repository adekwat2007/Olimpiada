using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class DepartmentManagerRequest
    {
        [Required]
        public int DepartmentID { get; set; }

        [Required]
        public int ManagerID { get; set; }
    }
}
