using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EventResponsible
    {
        [Required]
        public int EventID { get; set; }

        [Required]
        public int ResponsibleEmployeeID { get; set; }

        // Навигационные свойства
        public virtual Event Event { get; set; } = null!;
        public virtual Employee ResponsibleEmployee { get; set; } = null!;
    }
}
