using System.ComponentModel.DataAnnotations;

namespace EtAndHkIde.Archive.Models
{
    public class Collection
    {
        [Key]
        public long Id { get; set; }
        public  string Key { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ParentKey { get; set; } = string.Empty;
    }
}
