using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Articles
{
    public class RecollectionsModel : SitePageModel
    {
        public RecollectionsModel()
        {
            Title = "Recollections";
            Description = "William Adams Ide's Recollections, compiled and published in 1951.";
            PublishDate = new DateTime(2018, 12, 17);
            IsHighlight = true;
        }
    }
}