using System;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Infrastructure
{
    public class PageMetadata : IPageMetadata
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
            PreviewQuote = sitePageModel.PreviewQuote;
            PreviewImage = sitePageModel.PreviewImage;
            Tags = sitePageModel.Tags ?? Enumerable.Empty<string>();
            Citation = sitePageModel.Citation;
        }

        public string Path { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public string PreviewQuote { get; set; }
        public string PreviewImage { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public Citation Citation { get; set; }

        /// <summary>
        /// Set using index-relatedPages.json
        /// </summary>
        public IEnumerable<string> RelatedPagePaths { get; set; }

        public override string ToString() => Title;
    }
}