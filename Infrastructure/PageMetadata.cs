using System;
using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public class PageMetadata
    {
        public PageMetadata() { }

        public PageMetadata(SitePageModel sitePageModel)
        {
            Path = sitePageModel.Path;
            Title = sitePageModel.Title;
            Description = sitePageModel.Description;
            PublishDate = sitePageModel.PublishDate;
            IsHighlight = sitePageModel.IsHighlight;
            Tags = sitePageModel.Tags ?? new List<Tag>();
            Citation = sitePageModel.Citation;
        }

        public string Path { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool IsHighlight { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public Citation Citation { get; set; }

        public IEnumerable<PageMetadata> RelatedPages { get; set; }
    }
}