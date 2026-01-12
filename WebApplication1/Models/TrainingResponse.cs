namespace WebApplication1.Models
{
    public class TrainingResponse
    {
        public int TrainingID { get; set; }
        public string Date { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeDepartment { get; set; } = string.Empty;
        public List<string> Materials { get; set; } = new List<string>();
    }
}
