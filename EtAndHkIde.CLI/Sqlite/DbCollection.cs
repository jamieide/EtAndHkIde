using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EtAndHkIde.CLI.Sqlite
{
    internal class DbCollection
    {
        [Key]
        public string CollectionId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
