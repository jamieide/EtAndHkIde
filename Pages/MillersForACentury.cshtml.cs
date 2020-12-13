using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages
{
    public class MillersForACenturyModel : SitePageModel
    {
        public MillersForACenturyModel() : base("Millers For A Century")
        {
            Description = "A long newspaper article from The Caledonian published on the occasion of the 100th anniversary in 1913";
            PublishDate = new DateTime(2018, 12, 19);
            PreviewQuote = "The close of a century’s ownership finds Elmore T. Ide 74 years old but still at his desk giving the business the benefit of his long and successful experience.";
            Tags = new[]
            {
                TagValues.System.Featured,
                TagValues.People.TimothyIde,
                TagValues.People.JacobIde,
                TagValues.People.ElmoreIde,
                TagValues.People.HoraceIde,
                TagValues.People.WilliamIde,
                TagValues.Places.Passumpsic,
                TagValues.Places.StJohnsbury
            };
            Citation = new Citation(CitationType.Newspaper,
                @"http://chroniclingamerica.loc.gov/lccn/sn84023253/1913-12-17/ed-1/seq-3/",
                "St. Johnsbury Caledonian",
                "December 17 1913");
        }
    }
}