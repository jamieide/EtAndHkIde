using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages.LettersFromFlorida
{
    public class LetterFromFlorida_1876_02_18Model : SitePageModel
    {
        public LetterFromFlorida_1876_02_18Model()
        {
            Metadata = new PageMetadata
            {
                Title = "A Trip to Dunn's Lake",
                Description = "A visit to Dunn's Lake and an orange grove, and an exounter with a Florida Cracker. Published February 18, 1876.",
                PublishDate = new DateTime(2018, 12, 14),
                Citation = new Citation(CitationType.Newspaper,
                "http://chroniclingamerica.loc.gov/lccn/sn84023253/1876-02-18/ed-1/seq-1/",
                "St. Johnsbury Caledonian",
                "February 18, 1876"),
                PreviewQuote = "His apparatus was rather primitive, consisting of two iron rollers set in a wooden frame, and turned by a horse and mule attached to a sweep. The cane was crushed between these rollers, and the juice was caught in a barrel underneath. he gave us some of it to drink, and we found it much sweeter than sap.",
                IsPrimary = false,
                Tags = new[] { TagValues.People.HoraceIde }
            };
        }

        public void OnGet()
        {
        }
    }
}
