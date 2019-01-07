using System;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Infrastructure
{
    public class PageMetadata
    {
        public PageMetadata()
        {
            // needed for JSON deserialization
        }

        public PageMetadata(string path, SitePageModel sitePageModel)
        {
            Path = path;
            Title = sitePageModel.Title;
            Description = sitePageModel.Description;
            PublishDate = sitePageModel.PublishDate;
            Tags = sitePageModel.Tags ?? Enumerable.Empty<string>();
            Citation = sitePageModel.Citation;
        }

        public string Path { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public Citation Citation { get; set; }

        /// <summary>
        /// Set using index-relatedPages.json
        /// </summary>
        public IEnumerable<string> RelatedPagePaths { get; set; }

        public override string ToString() => Title;
    }
}