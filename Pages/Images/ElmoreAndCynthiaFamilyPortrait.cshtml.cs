using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Images
{
    public class ElmoreAndCynthiaFamilyPortraitModel : SitePageModel
    {
        public ElmoreAndCynthiaFamilyPortraitModel() : base("Elmore and Cynthia Ide Family Portrait")
        {
            Description = "A family portrait of Elmore and Cynthia Ide circa 1895.";
            PublishDate = new DateTime(2019, 1, 12);
            Tags = new[] { TagValues.ElmoreIde, TagValues.CynthiaIde };
        }
    }
}