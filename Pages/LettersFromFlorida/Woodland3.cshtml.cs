using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages.LettersFromFlorida
{
    public class Woodland3Model : SitePageModel
    {
        public Woodland3Model()
        {
            Metadata = new PageMetadata
            {
                Title = "Woodland 3",
                Description = "Correspondence from Horace K. Ide to The Caledonian newspaper in 1876.",
                PublishDate = new DateTime(2018, 12, 14)
            };
        }
    }
}