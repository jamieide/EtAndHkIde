using System.ComponentModel.DataAnnotations;

namespace EtAndHkIde.CLI.Sqlite
{
    internal class DbItemTag
    {
        [Key]
        public long Id { get; set; }

        public string ItemId { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
