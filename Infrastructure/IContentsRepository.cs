using System.Collections.Generic;

namespace EtAndHkIde.Infrastructure
{
    public interface IContentsRepository
    {
        IEnumerable<ContentPage> GetPages(int? count);
        IEnumerable<ContentPage> GetHighlightPages(int? count);

        IEnumerable<ContentItem> GetImages(string path);
        ContentItem GetImage(string path, string imageFileName);
    }
}