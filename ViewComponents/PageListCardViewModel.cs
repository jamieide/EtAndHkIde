﻿using System.Collections.Generic;
using EtAndHkIde.Infrastructure;

namespace EtAndHkIde.ViewComponents
{
    public class PageListCardViewModel
    {
        public string Title { get; set; }
        public IEnumerable<ContentPage> Pages { get; set; }
    }
}