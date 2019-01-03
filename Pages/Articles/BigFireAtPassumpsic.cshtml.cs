using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages.Articles
{
    public class BigFireAtPassumpsicModel : SitePageModel
    {

        public BigFireAtPassumpsicModel()
        {
            Title = "Big Fire at Passumpsic";
            Description = "A newspaper article describing the 1904 fire that engulfed the second Passumpsic mill.";
            PublishDate = new DateTime(2019, 1, 2);
            Citation = new Citation(CitationType.Newspaper,
                "http://chroniclingamerica.loc.gov/lccn/sn84023253/1904-12-21/ed-1/seq-1/",
                "St. Johnsbury Caledonian",
                "December 21, 1904");
            Tags = new[] { Tag.Passumpsic };
        }

        public void OnGet()
        {

        }
    }
}