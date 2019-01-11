using System;

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

        public static string ForTag(string tagValue)
        {
            if (tagValue == TagValues.Featured)
            {
                return "tag fas fa-award";
            }
            if (TagValues.PersonTags.Contains(tagValue))
            {
                return "tag fas fa-user";
            }
            if (TagValues.PlaceTags.Contains(tagValue))
            {
                return "tag fas fa-map-pin";
            }
            return "tag fas fa-tag";
        }
    }
}