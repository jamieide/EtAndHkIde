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
                Tag.Featured,
                Tag.TimothyIde,
                Tag.JacobIde,
                Tag.ElmoreIde,
                Tag.HoraceIde,
                Tag.WilliamIde,
                Tag.RichardIde,
                Tag.TimIde,
                Tag.GeorgeGray,
                Tag.Passumpsic,
                Tag.StJohnsbury
            };
            Citation = new Citation(CitationType.Pdf, @"/articles/Recollections/Recollections.pdf");
        }
    }
}