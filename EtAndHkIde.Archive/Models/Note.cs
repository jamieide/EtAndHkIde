using System.ComponentModel.DataAnnotations;

namespace EtAndHkIde.Archive.Models
{
    public class Note
    {
        [Key]
        public long Id { get; set; }

        public string NoteId { get; set; } = string.Empty;
        public string ItemId { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
    }
}
