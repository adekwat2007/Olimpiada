using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class TrainingMaterial
    {
        [Required]
        public int TrainingID { get; set; }

        [Required]
        public int MaterialID { get; set; }

        // Навигационные свойства
        public virtual TrainingCalendar Training { get; set; } = null!;
        public virtual Material Material { get; set; } = null!;
    }
}
