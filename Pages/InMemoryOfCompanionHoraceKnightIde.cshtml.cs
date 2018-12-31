using EtAndHkIde.Infrastructure;
using System;

namespace EtAndHkIde.Pages
{
    public class InMemoryOfCompanionHoraceKnightIdeModel : SitePageModel
    {
        public InMemoryOfCompanionHoraceKnightIdeModel()
        {
            Title = "In Memory Of Companion Horace Knight Ide";
            Description = "A memorial to H. K. Ide published by the Military Order of the Loyal Legion of the United States in 1897.";
            PublishDate = new DateTime(2018, 12, 17);
        }
    }
}