using System;
using System.Collections.Generic;
using System.Linq;

namespace EtAndHkIde.Models
{
    public class InMemorySiteRepository : ISiteRepository
    {
        private readonly IEnumerable<Page> _pages = new List<Page> {
            new Page("RandallArmorPhotos", "Randall Armor Photos", new DateTime(2018, 12, 15), Tags.Places.StJohnsbury),
            new Page("LettersFromFlorida/Savannah", "Savannah", new DateTime(2018, 12, 14)),
            new Page("LettersFromFlorida/Woodland1", "Woodland 1", new DateTime(2018, 12, 14)),
            new Page("LettersFromFlorida/Woodland2", "Woodland 2", new DateTime(2018, 12, 14)),
            new Page("LettersFromFlorida/Woodland3", "Woodland 3", new DateTime(2018, 12, 14)),
            new Page("PassumpsicMillPhotos", "Passumpsic Mill Photos", new DateTime(2018, 12, 16)),
            new Page("VermontMillingDynasty", "A Vermont Milling Dynasty", new DateTime(2018, 12, 17)),
            new Page("MillersForFiveGenerations", "Millers For Five Generations", new DateTime(2018, 12, 17)),
            new Page("Recollections", "Recollections", new DateTime(2018, 12, 17)),
            new Page("MyGrandfather", "My Grandfather: A Biographical Sketch", new DateTime(2018, 12, 17)),
            new Page("ETIdeInIndiana", "E. T. Ide in Indiana", new DateTime(2018, 12, 17)),
            new Page("InMemoryOfCompanionHoraceKnightIde", "In Memory Of Companion Horace Knight Ide", new DateTime(2018, 12, 17)),
            new Page("MillersForACentury", "Millers For A Century", new DateTime(2018, 12, 19))
        };

        private readonly IEnumerable<ImageCollection> _imageCollections = new List<ImageCollection>()
        {
            new ImageCollection("Randall Armor Photos")
            {
                Images = new []
                {
                    new Image("RandallArmor/armor_101231-6151.jpg", "Randall Armor 1", new DateTime(2018, 12, 15)),
                    new Image("RandallArmor/armor_101231-6230.jpg", "Randall Armor 2", new DateTime(2018, 12, 15)),
                    new Image("RandallArmor/armor_101231-6243.jpg", "Randall Armor 3", new DateTime(2018, 12, 15)),
                }
            },
            new ImageCollection("Passumpsic Mill Photos")
            {
                Images = new []
                {
                    new Image("Passumpsic/First-Passumpsic-Mill-edit.jpg", "First Passumpsic Mill", new DateTime(2018, 12, 16)),
                    new Image("Passumpsic/Ide's-Mill-postcard-18xx-edit.jpg", "Ide's Mill Postcard", new DateTime(2018, 12, 16)),
                    new Image("Passumpsic/Second-Passumpsic-Mill-1884-edit.jpg", "Second Passumpsic Mill 1884", new DateTime(2018, 12, 16)),
                }
            }
        };

        public IEnumerable<Page> GetPages()
        {
            return _pages;
        }

        public IEnumerable<Page> GetRecentPages(int count)
        {
            return GetPages().OrderByDescending(x => x.PublishDate).Take(count).ToList();
        }

        public ImageCollection GetImageCollection(string name)
        {
            return _imageCollections.SingleOrDefault(x => x.Name == name);
        }
    }
}