using EtAndHkIde.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Pages.LettersFromFlorida
{
    public class IndexModel : SitePageModel
    {
        private readonly ISiteRepository _siteRepository;

        public IndexModel()
        {
            Metadata = new PageMetadata
            {
                Title = "Letters From Florida",
                Description = "A collection of letters written by Horace Ide to the editor of the Caledonian giving colorful descriptions of his trips to Florida.",
                PreviewQuote = "The woman had on an old, dirty calico dress, open in front; shoes, but no stockings, smoked a pipe, and could beat any Yankee expectorating at a mark. They had a little horse and cart, and a few kettles, etc. Something like the following conversation ensued...",
                PublishDate = new DateTime(2021, 1, 18),
                Tags = new[] { TagValues.People.HoraceIde }
            };
        }

        [ActivatorUtilitiesConstructor]
        public IndexModel(ISiteRepository siteRepository) : this()
        {
            _siteRepository = siteRepository;
        }

        public void OnGet()
        {
            // todo have to use underscores...
            var pagePaths = new[]
            {
                "/LettersFromFlorida/LetterFromFlorida-1876-01-21",
                "/LettersFromFlorida/LetterFromFlorida-1876-02-04",
                "/LettersFromFlorida/LetterFromFlorida-1876-02-18",
                "/LettersFromFlorida/LetterFromFlorida-1876-02-25",
            };
            FloridaPages = pagePaths.Select(x => _siteRepository.GetPage(x));
        }

        public IEnumerable<PageMetadata> FloridaPages { get; private set; }
    }
}
