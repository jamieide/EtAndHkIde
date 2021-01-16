namespace EtAndHkIde.Infrastructure
{
    public static class Icons
    {
        public const string Home = "fas fa-home";
        public const string Articles = "fas fa-newspaper";
        public const string Blog = "fas fa-bullhorn";
        public const string Images = "fas fa-images";
        public const string Tags = "fas fa-tag";
        public const string About = "fas fa-info";
        public const string Recent = "fas fa-clock";

        public static string ForTag(string tagValue)
        {
            if (tagValue == TagValues.System.Featured)
            {
                return "tag fas fa-award";
            }
            if (TagValues.People.All.Contains(tagValue))
            {
                return "tag fas fa-user";
            }
            if (TagValues.Places.All.Contains(tagValue))
            {
                return "tag fas fa-map-pin";
            }
            return "tag fas fa-tag";
        }

        public static string ForPath(string path)
        {
            switch (path)
            {
                case var p when p.StartsWith("/Articles"):
                    return Articles;
                case var p when p.StartsWith("/Blog"):
                    return Blog;
                case var p when p.StartsWith("/Images"):
                    return Images;
                default:
                    return "";
            }
        }
    }
}