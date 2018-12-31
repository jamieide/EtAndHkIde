using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class VermontMillingDynastyModel : SitePageModel
    {
        public VermontMillingDynastyModel()
        {
            Title = "A Vermont Milling Dynasty";
            Description = "An article from the September 1958 issue of Eastern Feed Merchant.";
            PublishDate = new DateTime(2018, 12, 17);
        }
    }
}