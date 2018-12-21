using System;

namespace EtAndHkIde.Infrastructure
{
    public class ContentItem
    {
        public ContentItem(string path, IContent content)
        {
            Path = path;
            Title = content.Title;
            Description = content.Description;
            PublishDate = content.PublishDate.GetValueOrDefault();
        }

        public string Path { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime PublishDate { get; }
    }
}