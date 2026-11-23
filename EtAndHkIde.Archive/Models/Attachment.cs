using System.ComponentModel.DataAnnotations;

namespace EtAndHkIde.Archive.Models
{
    public class Attachment
    {
        [Key]
        public long Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public long ItemId { get; set; }
        public string LinkMode { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
    }
}
