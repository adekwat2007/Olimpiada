namespace WebApplication1.Models
{
    public class EventStatusResponse
    {
        public int StatusID { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public int EventCount { get; set; }
    }
}
