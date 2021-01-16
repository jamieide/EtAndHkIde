using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class PassumpsicRiverMillEnds152YearCareerModel : SitePageModel
    {
        public PassumpsicRiverMillEnds152YearCareerModel()
        {
            Metadata = new PageMetadata
            {
                Title = "Passumpsic River Mill Ends 152-Year Career",
                Description = "Describes the closing of the Passumpsic branch office in 1965.",
                PublishDate = new DateTime(2019, 12, 14),
                PreviewQuote = "Last Saturday the firm closed its doors on the banks of the Passumpsic River where it had been a grain supplier and miller for area residents.",
                Citation = new Citation(CitationType.Newspaper,
                null, //"https://vsara.newspapers.com/image/199368941", //link requires sign-in
                "Burlington Free Press",
                "April 1, 1965"),
                Tags = new[] { TagValues.Places.Passumpsic }
            };
        }

        public void OnGet()
        {

        }
    }
}