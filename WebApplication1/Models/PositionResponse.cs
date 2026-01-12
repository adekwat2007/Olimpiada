namespace WebApplication1.Models
{
    public class PositionResponse
    {
        public int PositionID { get; set; }
        public string PositionName { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public int EmployeeCount { get; set; }
    }
}
