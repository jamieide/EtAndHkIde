using System;

namespace EtAndHkIde.Infrastructure
{
    interface IPageMetadata
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public string PreviewQuote { get; set; }
        public string PreviewImage { get; set; }
    }
}
