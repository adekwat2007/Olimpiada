namespace WebApplication1.Models
{
    public class DayOffResponse
    {
        public int DayOffID { get; set; }
        public string Date { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
    }
}
