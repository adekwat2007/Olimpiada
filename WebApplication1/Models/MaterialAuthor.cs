using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MaterialAuthor
    {
        [Required]
        public int MaterialID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        // Навигационные свойства
        public virtual Material Material { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;
    }
}
