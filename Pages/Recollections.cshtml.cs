using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class RecollectionsModel : SitePageModel
    {
        public RecollectionsModel() : base()
        {
            Metadata = new PageMetadata
            {
                Title = "Recollections",
                Description = "William Adams Ide's Recollections were compiled and published in 1951 as a booklet by his great nephew Donald Powell. They provide a tremendous insight into the history and the people behind the business.",
                PublishDate = new DateTime(2018, 12, 17),
                PreviewQuote = "I will write down some memories in a rambling manner that may be of interest and amusement in future days.",
                Tags = new[]
                {
                    TagValues.System.Featured,
                    TagValues.People.TimothyIde,
                    TagValues.People.JacobIde,
                    TagValues.People.ElmoreIde,
                    TagValues.People.HoraceIde,
                    TagValues.People.WilliamIde,
                    TagValues.People.RichardIde,
                    TagValues.People.TimIde,
                    TagValues.People.GeorgeGray,
                    TagValues.Places.Passumpsic,
                    TagValues.Places.StJohnsbury
                },
                Citation = new Citation(CitationType.Pdf, @"/pages/Recollections/Recollections.pdf")
            };
        }
    }
}