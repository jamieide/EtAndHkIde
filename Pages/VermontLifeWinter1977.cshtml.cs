using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages
{
    public class VermontLifeWinter1977Model : SitePageModel
    {
        public VermontLifeWinter1977Model() : base("Vermont Life Winter 1977")
        {
            Description = "An article from the Winter 1977 edition of Vermont Life magazine.";
            PublishDate = new DateTime(2019, 1, 18);
            PreviewQuote = "The whole structure is rather like a giant, compartmentalized hour glass, in which the constant flow of grain measures the passage of the working day.";
            PreviewImage = "articles/VermontLifeWinter1977/vermont-life-winter-1977-005.jpg";
            Citation = new Citation(CitationType.Pdf, "/articles/VermontLifeWinter1977/Vermont Life Winter 1977.pdf");
            Tags = new[]
            {
                TagValues.People.RichardIde,
                TagValues.People.TimIde,
                TagValues.People.RobertIde,
                TagValues.People.MaitlandBean,
                TagValues.Places.StJohnsbury
            };
        }
    }
}