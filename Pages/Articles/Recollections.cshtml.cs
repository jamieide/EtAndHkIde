using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Articles
{
    public class RecollectionsModel : SitePageModel
    {
        public RecollectionsModel() : base("Recollections")
        {
            Description = "William Adams Ide's Recollections were compiled and published in 1951 as a booklet by his great nephew Donald Powell. They provide a tremendous insight into the history and the people behind the business.";
            PublishDate = new DateTime(2018, 12, 17);
            Tags = new[]
            {
                TagValues.Featured,
                TagValues.TimothyIde,
                TagValues.JacobIde,
                TagValues.ElmoreIde,
                TagValues.HoraceIde,
                TagValues.WilliamIde,
                TagValues.RichardIde,
                TagValues.TimIde,
                TagValues.GeorgeGray,
                TagValues.Passumpsic,
                TagValues.StJohnsbury
            };
            Citation = new Citation(CitationType.Pdf, @"/articles/Recollections/Recollections.pdf");
        }
    }
}