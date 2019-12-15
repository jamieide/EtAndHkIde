using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages.Articles
{
    public class IdeMillersOfStJohnsburyBeganIn1813Model : SitePageModel
    {
        public IdeMillersOfStJohnsburyBeganIn1813Model() : base("Ide Millers of St. Johnsbury Began in 1813; Now Run by Fifth Generation")
        {
            PublishDate = new DateTime(2019, 12, 15);
            Description = "A 1963 Burlington Free Press article on the occasion of the 150th anniversary of the company.";
            Citation = new Citation(CitationType.Newspaper,
                null, //https://vsara.newspapers.com/image/198974613,
                      "Burlington Free Press", "April 15, 1963");
            Tags = new[] { TagValues.Places.Passumpsic, TagValues.Places.StJohnsbury, TagValues.People.RichardIde };
        }

        public void OnGet()
        {

        }
    }
}