using System;
using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public interface IPageMetadata
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public string PreviewQuote { get; set; }
        public string PreviewImage { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public Citation Citation { get; set; }
    }
}
