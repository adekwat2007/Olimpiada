// Models/DocumentAccess.cs
namespace WebApplication1.Models
{
    public class DocumentAccess
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public int EmployeeId { get; set; }
        public string AccessLevel { get; set; } = "Read"; // Read, Write, Admin
        public DateTime GrantedAt { get; set; }
        public int? GrantedBy { get; set; }

        // Навигационные свойства
        public virtual Document? Document { get; set; }
        public virtual Employee? Employee { get; set; }
        public virtual Employee? Granter { get; set; }
    }
}