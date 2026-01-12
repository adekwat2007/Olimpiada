using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MaterialAuthorRequest
    {
        [Required]
        public int MaterialID { get; set; }

        [Required]
        public int EmployeeID { get; set; }
    }
}
