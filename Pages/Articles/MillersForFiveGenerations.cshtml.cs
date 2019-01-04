using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Articles
{
    public class MillersForFiveGenerationsModel : SitePageModel
    {
        public MillersForFiveGenerationsModel() : base("Millers For Five Generations")
        {
            Description = "A booklet published in 1953 on the occasion of the company's 140th anniversary.";
            PublishDate = new DateTime(2018, 12, 17);
            Tags = new[]
            {
                Tag.Featured,
                Tag.TimothyIde,
                Tag.JacobIde,
                Tag.ElmoreIde,
                Tag.WilliamIde,
                Tag.RichardIde,
                Tag.Passumpsic,
                Tag.StJohnsbury
            };
            Citation = new Citation(CitationType.Pdf, @"/articles/MillersForFiveGenerations/Millers-for-Five-Generations.pdf");
        }
    }
}