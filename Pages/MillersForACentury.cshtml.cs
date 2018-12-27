using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class MillersForACenturyModel : ArticlePageModel
    {
        public MillersForACenturyModel()
        {
            Title = "Millers For A Century";
            Description = "A long newspaper article from The Caledonian published on the occasion of the 100th anniversary in 1913";
            PublishDate = new DateTime(2018, 12, 19);
        }
    }
}