using System;

namespace EtAndHkIde.Infrastructure
{
    public class ContentItem
    {
        public string Path { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Copyright { get; set; }
        public DateTime PublishDate { get; set; }
    }
}