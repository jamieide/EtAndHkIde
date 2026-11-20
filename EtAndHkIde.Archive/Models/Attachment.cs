using System.ComponentModel.DataAnnotations;

namespace EtAndHkIde.Archive.Models
{
    public class Attachment
    {
        [Key]
        public long Id { get; set; }

        public string AttachmentId { get; set; } = string.Empty;
        public string ItemId { get; set; } = string.Empty;
        public string LinkMode { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
    }
}
