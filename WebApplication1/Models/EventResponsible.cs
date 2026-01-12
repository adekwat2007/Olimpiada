// Models/EventResponsible.cs (ИСПРАВЛЕННАЯ версия)
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("EventResponsible")]
    public class EventResponsible
    {
        // В EF Core 8+ нужно использовать KeyAttribute без Order
        // ИЛИ настроить через Fluent API

        public int EventID { get; set; }
        public int ResponsibleEmployeeID { get; set; }

        [ForeignKey("EventID")]
        public virtual Event? Event { get; set; }

        [ForeignKey("ResponsibleEmployeeID")]
        public virtual Employee? ResponsibleEmployee { get; set; }
    }
}