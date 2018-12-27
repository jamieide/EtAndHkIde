using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class MillersForFiveGenerationsModel : ArticlePageModel
    {
        public MillersForFiveGenerationsModel()
        {
            Title = "Millers For Five Generations";
            Description = "A booklet published in 1953 on the occasion of the company's 140th anniversary.";
            PublishDate = new DateTime(2018, 12, 17);
        }
    }
}