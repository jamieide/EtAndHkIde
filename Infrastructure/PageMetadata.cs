using System;
using System.Collections.Generic;

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
            Tags = sitePageModel.Tags ?? new List<Tag>();
            Citation = sitePageModel.Citation;
        }

        public string Path { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }

        public IEnumerable<Tag> Tags { get; set; }

        public Citation Citation { get; set; }

        public override string ToString() => Title;
    }
}