﻿using System;
using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages
{
    public class TheWharfModel : SitePageModel
    {
        public TheWharfModel() : base("The Wharf")
        {
            Description = "Article about the development of Bay Street in St. Johnsbury.";
            PublishDate = new DateTime(2019, 12, 21);
            PreviewQuote = "A few years ago it was an eyesore, a swamp, an outlet for a number of sewers, a dumping place for rubbish and a dwelling place for bull-frogs.";
            Citation = new Citation(CitationType.Newspaper,
                "/articles/TheWharf/St_Johnsbury_Republican_Wed__Mar_6__1901_.jpg",
                "St. Johnsbury Republican",
                "March 6, 1901");
            Tags = new[] { TagValues.Places.StJohnsbury, TagValues.People.ElmoreIde };
        }

        public void OnGet()
        {

        }
    }
}