using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class EtIdeInIndianaModel : SitePageModel
    {
        public EtIdeInIndianaModel()
        {
            Metadata = new PageMetadata
            {
                Title = "E. T. Ide in Indiana",
                Description = "A letter from E. T. to American Miller in Feb. 1914 describing the time he spent learning the milling trade in Indiana in 1865.",
                PublishDate = new DateTime(2018, 12, 17),
                UpdatedDate = new DateTime(2020, 2, 20),
                PreviewQuote = "In 1865 I worked some weeks as millwright, remodeling this mill.",
                Tags = new[] { TagValues.People.ElmoreIde },
                Citation = new Citation(CitationType.Magazine,
                @"https://books.google.com/books?id=eso0AQAAMAAJ&amp,pg=PA110#v=onepage&amp,q&amp,f=false",
                "American Miller",
                "February 1914")
            };
        }
    }
}
