using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class InterviewRequest
    {
        [Required]
        public int EmployeeID { get; set; }

        [Required]
        public DateTime InterviewDateTime { get; set; }

        [Required]
        public int CandidateID { get; set; }
    }
}
