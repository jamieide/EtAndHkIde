using System.ComponentModel.DataAnnotations;

namespace EtAndHkIde.Archive.Models
{
    public class ItemAttribute
    {
        [Key]
        public long Id { get; set; }

        public string ItemId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
