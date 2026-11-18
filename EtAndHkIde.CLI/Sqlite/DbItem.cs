using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EtAndHkIde.CLI.Sqlite
{
    internal class DbItem
    {
        [Key]
        public string ItemId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Abstract { get; set; } = string.Empty;
    }
}
