using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Articles
{
    public class MyGrandfatherModel : SitePageModel
    {
        public MyGrandfatherModel()
        {
            Title = "My Grandfather";
            Description = "A biographical sketch of Elmore T. Ide.";
            PublishDate = new DateTime(2018, 12, 17);
        }
    }
}