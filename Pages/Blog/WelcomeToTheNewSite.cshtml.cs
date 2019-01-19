using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Blog
{
    public class WelcomeToTheNewSiteModel : SitePageModel
    {
        public WelcomeToTheNewSiteModel() : base("Welcome to the new site!")
        {
            Description = "Pardon the dust and noise, just because it's open doesn't mean it's finished.";
            PublishDate = new DateTime(2019, 1, 18);
        }
    }
}