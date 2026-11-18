using EtAndHkIde.CLI.Sqlite;
using EtAndHkIde.CLI.Zotero;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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


// demo collection: 7C72VRIF
// Ide collection: NJVGILN7
var collectionKey = "NJVGILN7";

var zotero = new ZoteroLocalApiService();

var options = new DbContextOptionsBuilder<EtAndHkIdeDbContext>()
    .UseSqlite("Data source=C:\\Users\\jamie\\source\\EtAndHkIdeDb\\EtAndHkIde.sqlite")
    .Options;
var dbContext = new EtAndHkIdeDbContext(options);

var importService = new ZoteroImportService(zotero, dbContext);
await importService.ExecuteAsync(collectionKey);



Console.WriteLine("Press any key");
Console.ReadKey();