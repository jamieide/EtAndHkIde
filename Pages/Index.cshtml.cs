﻿using EtAndHkIde.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EtAndHkIde.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IContentsRepository _contentsRepository;

        public IndexModel(IContentsRepository contentsRepository)
        {
            _contentsRepository = contentsRepository;
        }

        public int ImageCount { get; set; }

        public void OnGet()
        {
            ImageCount = _contentsRepository.ImageCount();
        }

    }

}