namespace WebApplication1.Models
{
    public class DepartmentResponse
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ManagerName { get; set; } = string.Empty;
        public int EmployeeCount { get; set; }
        public List<string> AdditionalManagers { get; set; } = new List<string>();
    }
}
