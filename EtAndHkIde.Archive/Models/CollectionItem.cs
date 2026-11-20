using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EtAndHkIde.Archive.Models
{
    public class CollectionItem
    {
        [Key]
        public long Id { get; set; }
        public string CollectionId { get; set; } = string.Empty;
        public string ItemId { get; set; } = string.Empty;
    }
}
