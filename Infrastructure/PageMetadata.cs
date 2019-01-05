using System;
using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public class PageMetadata
    {
        public PageMetadata(string path, SitePageModel sitePageModel)
        {
            Path = path;
            Title = sitePageModel.Title;
            Description = sitePageModel.Description;
            PublishDate = sitePageModel.PublishDate;
            Tags = sitePageModel.Tags ?? new List<Tag>();
            Citation = sitePageModel.Citation;
        }

        public string Path { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime? PublishDate { get; }

        public IEnumerable<Tag> Tags { get; }

        public Citation Citation { get; }

        public override string ToString() => Title;
    }
}