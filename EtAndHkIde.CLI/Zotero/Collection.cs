using System.Text.Json;

namespace EtAndHkIde.CLI.Zotero
{
    internal class Collection
    {
        public Collection(JsonElement json)
        {
            var data = json.GetProperty("data");
            Key = data.GetProperty("key").GetString() ?? throw new ArgumentException("key");
            Version = data.GetProperty("version").GetInt32();
            Name = data.GetProperty("name").GetString() ?? throw new ArgumentException("name");
            var parentCollection = data.GetProperty("parentCollection");
            if (parentCollection.ValueKind == JsonValueKind.String)
            {
                ParentCollectionKey = parentCollection.GetString() ?? string.Empty;
            }
            else
            {
                ParentCollectionKey = string.Empty;
            }

            var meta = json.GetProperty("meta");
            SubCollectionCount = meta.GetProperty("numCollections").GetInt32();
            ItemCount = meta.GetProperty("numItems").GetInt32();
        }

        public string Key { get; }
        public string Name { get; }
        public int Version { get; }
        public string ParentCollectionKey { get; }

        public int SubCollectionCount { get; }
        public int ItemCount { get; }
    }
}
