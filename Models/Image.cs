using System;

namespace EtAndHkIde.Models
{
    public class Image : IAsset
    {
        public Image(string path, string title, DateTime publishDate, params string[] tags)
        {
            Path = path;
            Title = title;
            PublishDate = publishDate;
            Tags = tags;
        }

        public string Path { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public string[] Tags { get; set; }
    }
}