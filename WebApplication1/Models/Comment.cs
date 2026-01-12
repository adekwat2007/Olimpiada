// Models/Comment.cs
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string Text { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Employee? Author { get; set; }

        [ForeignKey("DocumentId")]
        public virtual Document? Document { get; set; }
    }
}