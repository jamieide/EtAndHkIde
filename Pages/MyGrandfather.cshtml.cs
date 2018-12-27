using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class MyGrandfatherModel : ArticlePageModel
    {
        public MyGrandfatherModel()
        {
            Title = "My Grandfather";
            Description = "A biographical sketch of Elmore T. Ide.";
            PublishDate = new DateTime(2018, 12, 17);
        }
    }
}