using System.Text.Json;

namespace EtAndHkIde.CLI.Zotero
{
    internal static class ItemFactory
    {
        internal static ZoteroItem CreateItem(JsonElement json)
        {
            var data = json.GetProperty("data");
            var itemType = data.GetProperty("itemType").GetString();

            return itemType switch
            {
                "attachment" => new Attachment(json),
                "note" => new Note(json),
                _ => new Item(json)
            };
        }

    }
}
