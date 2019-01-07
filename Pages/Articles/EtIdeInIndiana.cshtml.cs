using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Articles
{
    public class EtIdeInIndianaModel : SitePageModel
    {
        public EtIdeInIndianaModel() : base("E. T. Ide in Indiana")
        {
            Description = "A letter from E. T. to American Miller in Feb. 1914 describing the time he spent learning the milling trade in Indiana in 1865.";
            PublishDate = new DateTime(2018, 12, 17);
            Tags = new[] {TagValues.ElmoreIde};
            Citation = new Citation(CitationType.Magazine,
                @"https://books.google.com/books?id=eso0AQAAMAAJ&amp;pg=PA110#v=onepage&amp;q&amp;f=false",
                "American Miller",
                "February 1914");
        }
    }
}
