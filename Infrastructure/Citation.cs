namespace EtAndHkIde.Infrastructure
{
    public class Citation
    {
        public Citation()
        {
            // needed for JSON deserialization
        }

        public Citation(CitationType type, string url)
        {
            Type = type;
            Url = url;
            Name = type == CitationType.Pdf ? "Adobe&reg; PDF" : "Citation link";
        }

        public Citation(CitationType type, string url, string name)
        {
            Type = type;
            Url = url;
            Name = name;
        }

        public Citation(CitationType type, string url, string name, string description)
        {
            Type = type;
            Url = url;
            Name = name;
            Description = description;
        }

        public CitationType Type { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}