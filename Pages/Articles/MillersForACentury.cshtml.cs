using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Articles
{
    public class MillersForACenturyModel : SitePageModel
    {
        public MillersForACenturyModel()
        {
            Title = "Millers For A Century";
            Description = "A long newspaper article from The Caledonian published on the occasion of the 100th anniversary in 1913";
            PublishDate = new DateTime(2018, 12, 19);
            IsHighlight = true;
            Tags = new[] { Tag.TimothyIde, Tag.JacobIde, Tag.ElmoreIde, Tag.HoraceIde, Tag.WilliamIde, Tag.Passumpsic, Tag.StJohnsbury };
            Citation = new Citation(CitationType.Newspaper,
                @"http://chroniclingamerica.loc.gov/lccn/sn84023253/1913-12-17/ed-1/seq-3/",
                "St. Johnsbury Caledonian",
                "December 17 1913");
        }
    }
}