using System;

namespace EtAndHkIde.Models
{
    public class Page
    {
        public Page(string path, string title, DateTime publishDate)
        {
            Path = path;
            Title = title;
            PublishDate = publishDate;
        }

        public string Path { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
    }
}