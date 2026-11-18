using System.ComponentModel.DataAnnotations;

namespace EtAndHkIde.CLI.Sqlite
{
    internal class DbItemAttribute
    {
        [Key]
        public long Id { get; set; }

        public string ItemId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
