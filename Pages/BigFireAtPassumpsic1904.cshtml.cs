using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class BigFireAtPassumpsic1904Model : SitePageModel
    {
        public BigFireAtPassumpsic1904Model()
        {
            Metadata = new PageMetadata
            {
                Title = "Big Fire at Passumpsic",
                Description = "A newspaper article describing the 1904 fire that engulfed the second Passumpsic mill.",
                PublishDate = new DateTime(2019, 1, 2),
                PreviewQuote = "The Ide grist mill stood on historic ground.",
                Citation = new Citation(CitationType.Newspaper,
                "http://chroniclingamerica.loc.gov/lccn/sn84023253/1904-12-21/ed-1/seq-1/",
                "St. Johnsbury Caledonian",
                "December 21, 1904"),
                Tags = new[] { TagValues.Places.Passumpsic },
            };
        }
    }
}