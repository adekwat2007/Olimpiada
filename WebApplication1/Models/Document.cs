// Models/Document.cs
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string Category { get; set; } = string.Empty;
        public bool HasComments { get; set; }

        // ВАЖНО: Добавьте эти свойства для связей!
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Employee? Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<DocumentAccess> DocumentAccesses { get; set; } = new List<DocumentAccess>();
    }
}