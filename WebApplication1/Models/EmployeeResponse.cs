namespace WebApplication1.Models
{
    public class EmployeeResponse
    {
        public int PersonalID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string PositionName { get; set; } = string.Empty;
        public string? ManagerName { get; set; }
        public string? WorkPhone { get; set; }
        public string? MobilePhone { get; set; }
        public string? Office { get; set; }
        public string Email { get; set; } = string.Empty;
        public string BirthDate { get; set; } = string.Empty;
        public string? AssistantName { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
