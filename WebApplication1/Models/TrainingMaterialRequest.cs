using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class TrainingMaterialRequest
    {
        [Required]
        public int TrainingID { get; set; }

        [Required]
        public int MaterialID { get; set; }
    }
}
