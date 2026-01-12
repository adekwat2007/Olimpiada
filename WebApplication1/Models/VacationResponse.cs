namespace WebApplication1.Models
{
    public class VacationResponse
    {
        public int VacationID { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public int DurationDays { get; set; }
        public string Department { get; set; } = string.Empty;
    }
}
