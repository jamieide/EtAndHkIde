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
                TagValues.Featured,
                TagValues.TimothyIde,
                TagValues.JacobIde,
                TagValues.ElmoreIde,
                TagValues.WilliamIde,
                TagValues.RichardIde,
                TagValues.Passumpsic,
                TagValues.StJohnsbury
            };
            Citation = new Citation(CitationType.Pdf, @"/articles/MillersForFiveGenerations/Millers-for-Five-Generations.pdf");
        }
    }
}