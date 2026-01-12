namespace WebApplication1.Models
{
    public class WorkCalendarBulkRequest
    {
        public List<WorkCalendarRequest> Days { get; set; } = new List<WorkCalendarRequest>();
    }
}
