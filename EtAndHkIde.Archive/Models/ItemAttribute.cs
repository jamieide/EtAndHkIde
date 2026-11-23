using System.ComponentModel.DataAnnotations;

namespace EtAndHkIde.Archive.Models
{
    // Would have used Attribute but that conflicts with System.Attribute
    public class ItemAttribute
    {
        [Key]
        public long Id { get; set; }
        public long ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
