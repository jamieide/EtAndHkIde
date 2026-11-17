using System.Text.Json;
using System.Text.Json.Serialization;

namespace EtAndHkIde.CLI.Zotero
{
    // For display in program.cs
    [JsonPolymorphic]
    [JsonDerivedType(typeof(Item))]
    [JsonDerivedType(typeof(Attachment))]
    [JsonDerivedType(typeof(Note))]
    internal abstract class ZoteroItem
    {
        public ZoteroItem(JsonElement json)
        {
            var data = json.GetProperty("data");
            Key = data.GetProperty("key").GetString() ?? throw new ArgumentException("key");
            Version = data.GetProperty("version").GetInt32();
            ItemType = data.GetProperty("itemType").GetString() ?? throw new ArgumentException("itemType");
            DateAdded = data.GetProperty("dateAdded").GetDateTime();
            DateModified = data.GetProperty("dateModified").GetDateTime();
            Title = GetStringValue(data, "title");
            ParentItemKey = GetStringValue(data, "parentItem");

            Tags = data.GetProperty("tags")
                .EnumerateArray()
                .Select(x => x.GetProperty("tag").GetString() ?? string.Empty)
                .ToList();

            // build attributes
            var excludedKeys = new HashSet<string>()
            {
                "key", "itemType", "title", "dateAdded", "dateModified", "accessDate",
                "note", "linkMode", "contentType", "path", "abstractNote", "date",
                "parentItem"
            };
            var attributeProperties = data
                .EnumerateObject()
                .Select(x => x)
                .Where(x => !excludedKeys.Contains(x.Name) && x.Value.ValueKind == JsonValueKind.String)
                .ToList();
            Attributes = attributeProperties
                .Select(x => new ItemAttribute(x.Name, x.Value.GetString() ?? string.Empty))
                .Where(x => x.Value != string.Empty)
                .ToList();
        }

        protected static string GetStringValue(JsonElement json, string propertyName)
        {
            if (json.TryGetProperty(propertyName, out var value) && value.ValueKind == JsonValueKind.String)
            {
                return value.GetString() ?? string.Empty;
            }
            return string.Empty;
        }

        public string Key { get; }
        public int Version { get; }
        public string ItemType { get; }
        public string Title { get; }
        public DateTime DateAdded { get; }
        public DateTime DateModified { get; }
        public string ParentItemKey { get; }

        public IReadOnlyList<string> Tags { get; }

        public IReadOnlyList<ItemAttribute> Attributes { get; }
    }

    internal class Item : ZoteroItem
    {
        public Item(JsonElement json) : base(json)
        {
            var data = json.GetProperty("data");
            Abstract = GetStringValue(data, "abstractNote");
            // Date is a string because some have partial or malformed values. Could be improved.
            Date = GetStringValue(data, "date");

            CollectionKeys = data.GetProperty("collections")
                .EnumerateArray()
                .Select(x => x.GetString() ?? throw new ArgumentException("Missing collection key."))
                .ToList();
        }

        public string Abstract { get; }
        public string Date { get; }

        public IReadOnlyList<string> CollectionKeys { get; }
    }

    internal class Attachment : ZoteroItem
    {
        public Attachment(JsonElement json) : base(json)
        {
            var data = json.GetProperty("data");
            LinkMode = GetStringValue(data, "linkMode");
            ContentType = GetStringValue(data, "contentType");
            Path = GetStringValue(data, "path");
        }

        public string LinkMode { get; }
        public string ContentType { get; }
        public string Path { get; }
    }

    internal class Note : ZoteroItem
    {
        public Note(JsonElement json) : base(json)
        {
            var data = json.GetProperty("data");
            Content = data.GetProperty("note").GetString() ?? string.Empty;
        }

        public string Content { get; }
    }

    internal sealed record ItemAttribute(string Name, string Value);
}
