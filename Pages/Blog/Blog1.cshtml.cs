using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Blog
{
    public class Blog1Model : SitePageModel
    {
        public Blog1Model() : base("Sample Blog Entry")
        {
            Description = "This is a sample blog entry.";
            PublishDate = new DateTime(2019, 1, 8);
        }
    }
}