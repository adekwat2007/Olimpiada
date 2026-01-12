using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class MaterialTypeCreateRequest
    {
        [Required]
        [MaxLength(100)]
        public string TypeName { get; set; } = string.Empty;
    }
}
