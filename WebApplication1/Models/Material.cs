using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Material
    {
        [Key]
        public int MaterialID { get; set; }

        [Required]
        [MaxLength(255)]
        public string MaterialName { get; set; } = string.Empty;

        public string? MaterialDescription { get; set; }

        [Required]
        public int MaterialTypeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Area { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "Активный";

        // Навигационные свойства
        public virtual MaterialType MaterialType { get; set; } = null!;
        public virtual ICollection<TrainingMaterial> TrainingMaterials { get; set; } = new List<TrainingMaterial>();
        public virtual ICollection<MaterialAuthor> MaterialAuthors { get; set; } = new List<MaterialAuthor>();
    }
}
