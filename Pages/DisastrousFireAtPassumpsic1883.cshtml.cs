using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class DisastrousFireAtPassumpsic1883Model : SitePageModel
    {
        public DisastrousFireAtPassumpsic1883Model() : base("Disastrous Fire at Passumpsic")
        {
            Description = "The St. Johnsbury Caledonian's account of the 1883 fire that destroyed the original Passumpsic mill.";
            PublishDate = new DateTime(2019, 1, 4);
            Citation = new Citation(CitationType.Newspaper, "https://chroniclingamerica.loc.gov/lccn/sn84023253/1883-10-12/ed-1/seq-3/", "St. Johnsbury Caledonian, October 12, 1883");
            Tags = new string[] { TagValues.People.ElmoreIde, TagValues.Places.Passumpsic };
        }
    }
}