using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class TrainingRequest
    {
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        public List<int>? MaterialIDs { get; set; }
    }
}
