using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Articles
{
    public class VermontMillingDynastyModel : SitePageModel
    {
        public VermontMillingDynastyModel() : base("A Vermont Milling Dynasty")
        {
            Description = "An article from the September 1958 issue of Eastern Feed Merchant.";
            PublishDate = new DateTime(2018, 12, 17);
            Tags = new[]
            {
                TagValues.TimothyIde,
                TagValues.JacobIde,
                TagValues.ElmoreIde,
                TagValues.HoraceIde,
                TagValues.WilliamIde,
                TagValues.RichardIde,
                TagValues.Passumpsic,
                TagValues.StJohnsbury
            };
            Citation = new Citation(CitationType.Pdf, @"/articles/VermontMillingDynasty/A-Vermont-Milling-Dynasty.pdf");
        }
    }
}