﻿using System;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.Pages.Articles
{
    public class InMemoryOfCompanionHoraceKnightIdeModel : SitePageModel
    {
        public InMemoryOfCompanionHoraceKnightIdeModel() : base("In Memory Of Companion Horace Knight Ide")
        {
            Description = "A memorial to H. K. Ide published by the Military Order of the Loyal Legion of the United States in 1897.";
            PublishDate = new DateTime(2018, 12, 17);
            Tags = new[] {TagValues.HoraceIde};
            Citation = new Citation(CitationType.Pdf, @"/articles/InMemoryOfCompanionHoraceKnightIde/MOLLUS-Circular-No.-3-Series-of-1897.pdf");
        }
    }
}