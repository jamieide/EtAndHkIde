using System;
using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public class PageMetadata
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public string PreviewQuote { get; set; }
        public string PreviewImage { get; set; }
        public IEnumerable<string> Tags { get; set; } = new string[0];
        public Citation Citation { get; set; }
        /// <summary>
        /// Flag to indicate if page should be included in lists, e.g. set to false for sub-pages linked from an indexed page.
        /// </summary>
        public bool IsListed { get; set; } = true;

        /// <summary>
        /// Set by indexer.
        /// </summary>
        public string Path { get; set; }
        public override string ToString() => Title;
    }
}