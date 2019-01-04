namespace EtAndHkIde.Infrastructure
{
    public class TagType
    {
        private TagType(string name, string icon)
        {
            Name = name;
            Icon = icon;
        }

        public string Name { get; }
        public string Icon { get; }

        public static TagType Person = new TagType("Person", "fas fa-user");
        public static TagType Place = new TagType("Place", "fas fa-map-pin");
        public static TagType Era = new TagType("Era", "fas fa-calendar-week");
        public static TagType Featured = new TagType("Featured", "fas fa-star");
    }
}