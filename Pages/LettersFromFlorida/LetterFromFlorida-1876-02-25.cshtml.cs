using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages.LettersFromFlorida
{
    public class LetterFromFlorida_1876_02_25Model : SitePageModel
    {
        public LetterFromFlorida_1876_02_25Model()
        {
            Metadata = new PageMetadata
            {
                Title = "Touring Hier's Groves",
                Description = "A trip to a Georgetown orange grove and an encounter with a wild hog. Published February 25, 1876.",
                PublishDate = new DateTime(2018, 12, 14),
                Citation = new Citation(CitationType.Newspaper,
                "http://chroniclingamerica.loc.gov/lccn/sn84023253/1876-02-25/ed-1/seq-2/",
                "St. Johnsbury Caledonian",
                "February 25, 1876"),
                PreviewQuote = "The hogs are lean, long-nosed, land-sharks; have a great faculty for finding a hole in a fence, and three of them will destroy an acre of sweet potatoes in one night. I found one in my field one day, and we made up our minds that that hog would not come in there any more. First we stopped up all the holes, and then armed with clubs entered the field intending to kill him.",
                IsListed = false,
                Tags = new[] { TagValues.People.HoraceIde }
            };
        }

        public void OnGet()
        {
        }
    }
}
