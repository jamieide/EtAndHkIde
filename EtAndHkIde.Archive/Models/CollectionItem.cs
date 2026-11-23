using System.ComponentModel.DataAnnotations;

namespace EtAndHkIde.Archive.Models
{
    public class CollectionItem
    {
        [Key]
        public long Id { get; set; }
        public long CollectionId { get; set; }
        public Collection Collection { get; set; } = null!;

        public long ItemId { get; set; }
        public Item Item { get; set; } = null!;
    }
}
