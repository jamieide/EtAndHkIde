namespace EtAndHkIde.Infrastructure
{
    public class SiteIndex
    {
        public PageMetadataCollection Pages { get; set; } = new PageMetadataCollection();
        public ImageMetadataCollection Images { get; set; } = new ImageMetadataCollection();
    }
}