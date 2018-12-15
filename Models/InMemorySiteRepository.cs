using System;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Models
{
    public class InMemorySiteRepository : ISiteRepository
    {
        private readonly IEnumerable<Page> _getPages = new List<Page> {
            new Page("RandallArmorPhotos", "Randall Armor Photos", new DateTime(2018, 12, 15), Tags.Places.StJohnsbury),
            new Page("LettersFromFlorida/Savannah", "Savannah", new DateTime(2018, 12, 14)),
            new Page("LettersFromFlorida/Woodland1", "Woodland 1", new DateTime(2018, 12, 14)),
            new Page("LettersFromFlorida/Woodland2", "Woodland 2", new DateTime(2018, 12, 14)),
            new Page("LettersFromFlorida/Woodland3", "Woodland 3", new DateTime(2018, 12, 14))
        };

        public IEnumerable<Page> GetPages()
        {
            return _getPages;
        }

        public IEnumerable<Page> GetRecentPages(int count)
        {
            return GetPages().OrderByDescending(x => x.PublishDate).Take(count).ToList();
        }
    }
}