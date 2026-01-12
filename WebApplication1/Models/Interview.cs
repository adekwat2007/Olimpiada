using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Interview
    {
        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public DateTime InterviewDateTime { get; set; }

        [Required]
        public int CandidateID { get; set; }

        // Навигационные свойства
        public virtual Employee Employee { get; set; } = null!;
        public virtual Candidate Candidate { get; set; } = null!;
    }
}
