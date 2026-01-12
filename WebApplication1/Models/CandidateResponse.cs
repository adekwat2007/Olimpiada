namespace WebApplication1.Models
{
    public class CandidateResponse
    {
        public int CandidateID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Passport { get; set; } = string.Empty;
        public string SNILS { get; set; } = string.Empty;
        public string INN { get; set; } = string.Empty;
        public string? AdditionalInfo { get; set; }
        public List<InterviewInfo> Interviews { get; set; } = new List<InterviewInfo>();
    }
}
