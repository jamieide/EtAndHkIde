using EtAndHkIde.Archive;
using EtAndHkIde.Archive.Models;
using System.Text.Json;

namespace EtAndHkIde.CLI.Zotero
{
    public class ZoteroImportService
    {
        private readonly ZoteroLocalApiService _zotero;
        private readonly ArchiveDbContext _dbContext;

        public string _rootCollectionKey { get; set; } = string.Empty;
        private Dictionary<string, string> _itemTypes = [];
        private Dictionary<string, string> _itemFields = [];
        private Dictionary<string, ItemContentType> _itemContentTypeByTag = [];

        public ZoteroImportService(ZoteroLocalApiService zotero, ArchiveDbContext dbContext)
        {
            _zotero = zotero;
            _dbContext = dbContext;
        }

        public async Task ExecuteAsync(string rootCollectionKey)
        {
            _rootCollectionKey = rootCollectionKey;

            using var txn = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                _itemTypes = await _zotero.GetItemTypesAsync();
                _itemFields = await _zotero.GetItemFieldsAsync();
                // removed ones that should not be attributes
                _itemFields.Remove("title");
                _itemFields.Remove("abstractNote");
                _itemFields.Remove("extra");
                _itemContentTypeByTag = new Dictionary<string, ItemContentType>()
                {
                    { "ict: Feature", ItemContentType.Feature },
                    { "ict: Article", ItemContentType.Article },
                    { "ict: Mention", ItemContentType.Mention },
                    { "ict: Advertising", ItemContentType.Advertising }
                };

                var zoteroCollection = await _zotero.GetCollectionAsync(rootCollectionKey);
                await ProcessCollection(zoteroCollection);

                txn.Commit();
            }
            catch
            {
                txn.Rollback();
                throw;
            }
        }

        private async Task ProcessCollection(ZoteroCollection zoteroCollection)
        {
            var collection = new Collection
            {
                Key = zoteroCollection.Key,
                Name = GetStringValue(zoteroCollection.Data, "name", true),
                ParentKey = _rootCollectionKey
            };
            _dbContext.Collection.Add(collection);
            await ProcessCollectionItems(collection);
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();

            var subCollections = await _zotero.GetSubCollectionsAsync(zoteroCollection.Key);
            foreach (var subCollection in subCollections)
            {
                await ProcessCollection(subCollection);
            }
        }

        private async Task ProcessCollectionItems(Collection collection)
        {
            var zoteroItems = await _zotero.GetItemsByCollectionAsync(collection.Key);
            var zoteroTopItems = zoteroItems
                .Where(x => !x.Data.ContainsKey("parentItem"));
            var zoteroChildItems = zoteroItems
                .Except(zoteroTopItems)
                .ToLookup(x => x.Data["parentItem"].GetString());
            // Remove stand-alone notes from top items
            zoteroTopItems = zoteroTopItems.Where(x => x.Data["itemType"].GetString() != "note");

            var zoteroTopItemKeys = zoteroTopItems.Select(x => x.Key).ToArray();
            var existingItems = _dbContext.Item
                .Where(x => zoteroTopItemKeys.Contains(x.Key))
                .ToDictionary(k => k.Key, v => v);

            foreach (var zoteroTopItem in zoteroTopItems)
            {
                CollectionItem collectionItem = new()
                {
                    Collection = collection
                };
                _dbContext.CollectionItem.Add(collectionItem);

                if (existingItems.TryGetValue(zoteroTopItem.Key, out var existingItem))
                {
                    collectionItem.Item = existingItem;
                }
                else
                {
                    collectionItem.Item = BuildItem(zoteroTopItem, zoteroChildItems[zoteroTopItem.Key]);
                }
            }
        }

        private Item BuildItem(ZoteroItem zoteroTopItem, IEnumerable<ZoteroItem> zoteroChildItems)
        {
            var itemType = GetStringValue(zoteroTopItem.Data, "itemType", true);

            var item = new Item
            {
                Key = zoteroTopItem.Key,
                ItemType = _itemTypes[itemType],
                Title = GetStringValue(zoteroTopItem.Data, "title"),
                Abstract = GetStringValue(zoteroTopItem.Data, "abstractNote")
            };

            AttachChildren(item, zoteroChildItems);

            // set creators
            var creators = new List<string>();
            foreach (var entry in zoteroTopItem.Data["creators"].EnumerateArray())
            {
                // These can be in the form { name, creatorType } or { firstName, lastName, creatorType }
                if (entry.GetPropertyCount() == 2)
                {
                    creators.Add($"{entry.GetProperty("name").GetString()} ({entry.GetProperty("creatorType").GetString()})");
                }
                else
                {
                    creators.Add($"{entry.GetProperty("firstName").GetString()} {entry.GetProperty("lastName").GetString()} ({entry.GetProperty("creatorType").GetString()})");
                }
            }
            item.Creators = string.Join(", ", creators);

            // set dates
            if (zoteroTopItem.Data.TryGetValue("date", out var dateElement) && DateTime.TryParse(dateElement.GetString(), out var dt))
            {
                item.Date = DateOnly.FromDateTime(dt);
            }
            item.DateAdded = zoteroTopItem.Data["dateAdded"].GetDateTime();
            item.DateModified = zoteroTopItem.Data["dateModified"].GetDateTime();

            // process tags
            if (zoteroTopItem.Data.TryGetValue("tags", out var tagsElement))
            {
                var itemContentTypeTag = tagsElement.EnumerateArray()
                    .Select(x => x.GetProperty("tag").GetString()!)
                    .FirstOrDefault(x => x.StartsWith("ict:")); // first one wins TODO add logging?
                if (itemContentTypeTag != null)
                {
                    item.ItemContentType = _itemContentTypeByTag[itemContentTypeTag];
                }
                else
                {
                    item.ItemContentType = ItemContentType.Undefined;
                }
            }

            // attach attributes
            foreach (var entry in zoteroTopItem.Data)
            {
                if (_itemFields.TryGetValue(entry.Key, out var localized))
                {
                    var attribute = new Archive.Models.ItemAttribute
                    {
                        Name = localized,
                        Value = entry.Value.GetString()!
                    };
                    item.Attributes.Add(attribute);
                }
            }

            return item;
        }

        private void AttachChildren(Item item, IEnumerable<ZoteroItem> zoteroChildItems)
        {
            // attachments and notes
            foreach (var zoteroChildItem in zoteroChildItems)
            {
                var itemType = zoteroChildItem.Data["itemType"].GetString()!;

                switch (itemType)
                {
                    case "attachment":
                        var attachment = new Attachment
                        {
                            Key = zoteroChildItem.Key,
                            LinkMode = GetStringValue(zoteroChildItem.Data, "linkMode", true),
                            ContentType = GetStringValue(zoteroChildItem.Data, "contentType", true),
                            Path = GetStringValue(zoteroChildItem.Data, "path") // not for linked_url
                        };
                        item.Attachments.Add(attachment);
                        break;
                    case "note":
                        var note = new Note
                        {
                            Key = zoteroChildItem.Key,
                            Content = GetStringValue(zoteroChildItem.Data, "note", true)
                        };
                        item.Notes.Add(note);
                        break;
                    default:
                        throw new Exception($"Unhandled item type '{itemType}'.");
                }
            }
        }

        private string GetStringValue(IDictionary<string, JsonElement> data, string key, bool required = false)
        {
            if (data.TryGetValue(key, out JsonElement value) && value.ValueKind == JsonValueKind.String)
            {
                return value.GetString()!;
            }
            if (required)
            {
                throw new Exception($"Required data field '{key}' was not found.");
            }
            return string.Empty;
        }
    }
}
