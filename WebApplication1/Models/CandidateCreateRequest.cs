using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class CandidateCreateRequest
    {
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public string Passport { get; set; } = string.Empty;

        [Required]
        public string SNILS { get; set; } = string.Empty;

        [Required]
        public string INN { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? AdditionalInfo { get; set; }
    }
}
