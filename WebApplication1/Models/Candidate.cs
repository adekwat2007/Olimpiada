using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Candidate
    {
        [Key]
        public int CandidateID { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Phone]
        [MaxLength(50)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Passport { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string SNILS { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string INN { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;

        public string? AdditionalInfo { get; set; }

        // Навигационные свойства
        public virtual ICollection<Interview> Interviews { get; set; } = new List<Interview>();
    }
}
