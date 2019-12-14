using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages.Articles
{
    public class PassumpsicRiverMillEnds152YearCareerModel : SitePageModel
    {
        public PassumpsicRiverMillEnds152YearCareerModel() : base("Passumpsic River Mill Ends 152-Year Career")
        {
            Description = "Describes the closing of the Passumpsic branch office in 1965.";
            PublishDate = new DateTime(2019, 12, 14);
            Citation = new Citation(CitationType.Newspaper,
                "https://vsara.newspapers.com/image/199368941",
                "Burlington Free Press",
                "April 1, 1965");
            Tags = new[] { TagValues.Places.Passumpsic };
        }

        public void OnGet()
        {

        }
    }
}