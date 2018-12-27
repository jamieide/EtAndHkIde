﻿using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public interface IContentsRepository
    {
        IEnumerable<ContentPage> GetPublishedContentPages(int? count, ContentPageType type);
        IEnumerable<ContentItem> GetContentItemsForPage(string path);

        IEnumerable<ContentItem> GetImages(string path);
        ContentItem GetImage(string path, string imageFileName);
    }
}