using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EtAndHkIde.Archive.Models
{
    public class Collection
    {
        [Key]
        public string CollectionId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}
