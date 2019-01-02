using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Articles
{
    public class VermontMillingDynastyModel : SitePageModel
    {
        public VermontMillingDynastyModel()
        {
            Title = "A Vermont Milling Dynasty";
            Description = "An article from the September 1958 issue of Eastern Feed Merchant.";
            PublishDate = new DateTime(2018, 12, 17);
            Tags = new[]
            {
                Tag.TimothyIde,
                Tag.JacobIde,
                Tag.ElmoreIde,
                Tag.HoraceIde,
                Tag.WilliamIde,
                Tag.RichardIde,
                Tag.Passumpsic,
                Tag.StJohnsbury
            };
            Citation = new Citation(CitationType.Pdf, @"/articles/VermontMillingDynasty/A-Vermont-Milling-Dynasty.pdf");
        }
    }
}