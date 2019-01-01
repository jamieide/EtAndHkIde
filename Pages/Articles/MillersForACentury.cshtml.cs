using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Articles
{
    public class MillersForACenturyModel : SitePageModel
    {
        public MillersForACenturyModel()
        {
            Title = "Millers For A Century";
            Description = "A long newspaper article from The Caledonian published on the occasion of the 100th anniversary in 1913";
            PublishDate = new DateTime(2018, 12, 19);
            IsHighlight = true;
            Tags = new[] { Tag.TimothyIde, Tag.JacobIde, Tag.ElmoreIde, Tag.Passumpsic, Tag.StJohnsbury };
        }
    }
}