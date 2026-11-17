using EtAndHkIde.CLI.Zotero;
using System.Text.Json;

Console.WriteLine("Hello, World!");

static void WriteJson(object value)
{
    var options = new JsonSerializerOptions
    {
        WriteIndented = true
    };
    Console.WriteLine(JsonSerializer.Serialize(value, options));
}

var zotero = new ZoteroLocalApiService();

var collections = await  zotero.GetCollectionsAsync();
WriteJson(collections);

// demo collection: 7C72VRIF
// Ide collection: NJVGILN7

var items = await zotero.GetByCollectionAsync("NJVGILN7");
WriteJson(items);

Console.ReadKey();