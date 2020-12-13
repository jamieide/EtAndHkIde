using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class IdeMillersOfStJohnsburyBeganIn1813Model : SitePageModel
    {
        public IdeMillersOfStJohnsburyBeganIn1813Model() : base("Ide Millers of St. Johnsbury Began in 1813; Now Run by Fifth Generation")
        {
            PublishDate = new DateTime(2019, 12, 15);
            PreviewQuote = "This is the record which surpasses all other companies under same-family management in Vermont, and perhaps in the country.";
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