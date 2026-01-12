using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MaterialCreateRequest
    {
        [Required]
        [MaxLength(255)]
        public string MaterialName { get; set; } = string.Empty;

        public string? MaterialDescription { get; set; }

        [Required]
        public int MaterialTypeID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Area { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Status { get; set; } = "Активный";

        public List<int>? AuthorIDs { get; set; }
    }
}
