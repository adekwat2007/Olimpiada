namespace WebApplication1.Models
{
    public class WorkScheduleResponse
    {
        public int ScheduleID { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string? TrainingDate { get; set; }
        public string? WorkCalendarDate { get; set; }
        public bool IsWorkDay { get; set; }
    }
}
