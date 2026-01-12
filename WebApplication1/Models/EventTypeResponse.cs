namespace WebApplication1.Models
{
    public class EventTypeResponse
    {
        public int EventTypeID { get; set; }
        public string EventTypeName { get; set; } = string.Empty;
        public int EventCount { get; set; }
    }
}
