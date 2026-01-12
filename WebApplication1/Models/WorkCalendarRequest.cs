using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class WorkCalendarRequest
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool IsWorkDay { get; set; }
    }
}
