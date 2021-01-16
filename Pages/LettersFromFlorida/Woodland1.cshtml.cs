using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages.LettersFromFlorida
{
    public class Woodland1Model : SitePageModel
    {
        public Woodland1Model()
        {
            Metadata = new PageMetadata
            {
                Title = "Woodland 1",
                Description = "Correspondence from Horace K. Ide to The Caledonian newspaper in 1876.",
                PublishDate = new DateTime(2018, 12, 14)
            };
        }
    }

}