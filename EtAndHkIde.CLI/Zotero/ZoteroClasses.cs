using System.Text.Json;

namespace EtAndHkIde.CLI.Zotero
{

    public class ZoteroCollection
    {
        public string Key { get; init; } = string.Empty;
        public Dictionary<string, JsonElement> Data { get; init; } = new();
    }

    public class ZoteroItem
    {
        public  string Key { get; init; } = string.Empty;
        public Dictionary<string, JsonElement> Data { get; init; } = new();
    }
}
