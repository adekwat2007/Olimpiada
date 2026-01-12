namespace WebApplication1.Models
{
    public class EventResponse
    {
        public int EventID { get; set; }
        public string EventName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string EventType { get; set; } = string.Empty;
        public string DateTime { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public List<string> ResponsibleEmployees { get; set; } = new List<string>();
    }
}
