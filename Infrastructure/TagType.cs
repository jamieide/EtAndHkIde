namespace EtAndHkIde.Infrastructure
{
    public class TagType
    {
        public TagType()
        {
            // needed for JSON deserialization
        }

        private TagType(string name, string icon)
        {
            Name = name;
            Icon = icon;
        }

        public string Name { get; set; }
        public string Icon { get; set; }

        public override string ToString() => Name;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return string.Equals(Name, ((Tag)obj).Name);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public static TagType Person = new TagType("Person", "fas fa-user");
        public static TagType Place = new TagType("Place", "fas fa-map-pin");
        public static TagType Era = new TagType("Era", "fas fa-calendar-week");
        public static TagType Featured = new TagType("Featured", "fas fa-star");
    }
}