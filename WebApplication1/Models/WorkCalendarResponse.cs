namespace WebApplication1.Models
{
    public class WorkCalendarResponse
    {
        public int DayID { get; set; }
        public string Date { get; set; } = string.Empty;
        public bool IsWorkDay { get; set; }
        public string DayOfWeek { get; set; } = string.Empty;
    }
}
