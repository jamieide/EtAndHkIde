namespace EtAndHkIde.Models
{
    public class ImageCollection
    {
        public ImageCollection(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public Image[] Images { get; set; }
    }
}