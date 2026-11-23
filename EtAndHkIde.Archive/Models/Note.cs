using System.ComponentModel.DataAnnotations;

namespace EtAndHkIde.Archive.Models
{
    public class Note
    {
        [Key]
        public long Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public long ItemId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
