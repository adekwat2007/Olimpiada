using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EventResponsibleRequest
    {
        [Required]
        public int EventID { get; set; }

        [Required]
        public int ResponsibleEmployeeID { get; set; }
    }
}
