using System;
using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public class PageMetadata
    {
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

        public string Path { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime? PublishDate { get; }
        public bool IsHighlight { get; }

        public IEnumerable<Tag> Tags { get; }

        public Citation Citation { get; }

        public PageMetadataCollection RelatedPages { get; } = new PageMetadataCollection();
    }
}