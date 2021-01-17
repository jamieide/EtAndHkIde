using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages.LettersFromFlorida
{
    public class LetterFromFlorida_1876_01_21Model : SitePageModel
    {
        public LetterFromFlorida_1876_01_21Model()
        {
            Metadata = new PageMetadata
            {
                Title = "From New York To Savannah",
                Description = "Horace describes the rail journey from New York to Savannah and reminisces about his Civil War service. Published January 21, 1876.",
                PublishDate = new DateTime(2018, 12, 14),
                Citation = new Citation(CitationType.Newspaper,
                "http://chroniclingamerica.loc.gov/lccn/sn84023253/1876-01-21/ed-1/seq-2/",
                "St. Johnsbury Caledonian",
                "January 21, 1876"),
                PreviewQuote = "We arrived at Salisbury about dark, and I tried to get something to eat from an old lady who had a table on the platform of the depot. She had boiled eggs, bread and fried squirrel, and offered to put me up a snack for one for 25 cents, or a snack for two for 50 cents.",
                IsListed = false,
                Tags = new[] { TagValues.People.HoraceIde }
            };
        }

        public void OnGet()
        {
        }
    }
}
