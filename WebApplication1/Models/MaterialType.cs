using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MaterialType
    {
        [Key]
        public int MaterialTypeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; } = string.Empty;

        // Навигационные свойства
        public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
    }
}
