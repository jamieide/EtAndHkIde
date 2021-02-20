using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages.LettersFromFlorida
{
    public class LetterFromFlorida_1876_02_04Model : SitePageModel
    {
        public LetterFromFlorida_1876_02_04Model()
        {
            Metadata = new PageMetadata
            {
                Title = "Savannah to Jacksonville",
                Description = "The journey from Savannah to Jacksonville over land and then further south by paddlewheeler on the St. Johns River. Published February 4, 1876.",
                PublishDate = new DateTime(2018, 12, 14),
                Citation = new Citation(CitationType.Newspaper,
                "http://chroniclingamerica.loc.gov/lccn/sn84023253/1876-02-04/ed-1/seq-2/",
                "St. Johnsbury Caledonian",
                "February 4, 1876"),
                PreviewQuote = "Arriving at Jacksonville about ten o'clock, P.M., we stopped at the St. John's House, kept by Mrs. Hudnall. Over the door of the dining-room was the motto, \"The Lord will Provide\" and we judged by the appearance of the table, that it was left almost entirely to him.",
                IsPrimary = false,
                Tags = new[] { TagValues.People.HoraceIde }
            };
        }
    }
}
