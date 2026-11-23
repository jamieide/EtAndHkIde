using EtAndHkIde.Archive;
using EtAndHkIde.CLI.Zotero;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        static void WriteJson(object value)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            Console.WriteLine(JsonSerializer.Serialize(value, options));
        }


        // demo collection: 7C72VRIF
        // Ide collection: NJVGILN7
        var collectionKey = "NJVGILN7";

        var zotero = new ZoteroLocalApiService();

        //var collection = await zotero.GetCollectionAsync(collectionKey);
        //WriteJson(collection);
        //var subCollections = await zotero.GetSubCollectionsAsync(collectionKey);
        //WriteJson(subCollections);

        //var items = await zotero.GetItemsByCollectionAsync2(collectionKey);
        //WriteJson(items);
        //var item = await zotero.GetItemAsync("ABC123");
        //WriteJson(item);

        var options = new DbContextOptionsBuilder<ArchiveDbContext>()
            .UseSqlite("Data source=C:\\Users\\jamie\\source\\EtAndHkIdeDb\\EtAndHkIde.sqlite")
            .Options;
        var dbContext = new ArchiveDbContext(options);

        var importService = new ZoteroImportService(zotero, dbContext);
        await importService.ExecuteAsync(collectionKey);



        Console.WriteLine("Press any key");
        Console.ReadKey();
    }
}