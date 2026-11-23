using EtAndHkIde.Archive;
using EtAndHkIde.Archive.Models;
using System.Text;
using System.Text.Json;

namespace EtAndHkIde.CLI.Zotero
{
    public class ZoteroImportService
    {
        private readonly ZoteroLocalApiService _zotero;
        private readonly ArchiveDbContext _dbContext;

        private IDictionary<string, string> _itemTypes = new Dictionary<string, string>();
        private IDictionary<string, IDictionary<string, string>> _itemTypeFields = new Dictionary<string, IDictionary<string, string>>();
        private IDictionary<string, ItemContentType> _itemContentTypeByTag;
        private HashSet<string> _processedItemKeys = [];

        public ZoteroImportService(ZoteroLocalApiService zotero, ArchiveDbContext dbContext)
        {
            _zotero = zotero;
            _dbContext = dbContext;

            _itemContentTypeByTag = new Dictionary<string, ItemContentType>
            {
                { "ict: Feature", ItemContentType.Feature },
                { "ict: Article", ItemContentType.Article },
                { "ict: Mention", ItemContentType.Mention },
                { "ict: Advertising", ItemContentType.Advertising }
            };
        }

        public async Task ExecuteAsync(string zoteroCollectionKey)
        {
            using var txn = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                _itemTypes = await _zotero.GetItemTypesAsync();
                var zoteroCollection = await _zotero.GetCollectionAsync(zoteroCollectionKey);
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
                CollectionId = zoteroCollection.Key,
                Name = GetStringValue(zoteroCollection.Data, "name", true)
            };
            _dbContext.Collection.Add(collection);
            await ProcessCollectionItems(zoteroCollection);
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();

            var subCollections = await _zotero.GetSubCollectionsAsync(zoteroCollection.Key);
            foreach (var subCollection in subCollections)
            {
                await ProcessCollection(subCollection);
            }
        }

        private async Task ProcessCollectionItems(ZoteroCollection zoteroCollection)
        {
            var zoteroItems = await _zotero.GetItemsByCollectionAsync(zoteroCollection.Key);

            foreach (var zoteroItem in zoteroItems)
            {
                var itemType = GetStringValue(zoteroItem.Data, "itemType", true);
                if (!_itemTypeFields.ContainsKey(itemType))
                {
                    var itemTypeFields = await _zotero.GetItemTypeFieldsAsync(itemType);
                    _itemTypeFields.Add(itemType, itemTypeFields);
                }

                switch (itemType)
                {
                    case "note":
                        ProcessNote(zoteroItem);
                        break;
                    case "attachment":
                        ProcessAttachment(zoteroItem);
                        break;
                    default:
                        ProcessItem(zoteroCollection, zoteroItem, itemType);
                        ProcessItemAttributes(zoteroItem, itemType);
                        break;
                }
            }
        }

        private void ProcessItem(ZoteroCollection zoteroCollection, ZoteroItem zoteroItem, string itemType)
        {
            // Add relationship to collection
            var collectionItem = new CollectionItem
            {
                CollectionId = zoteroCollection.Key,
                ItemId = zoteroItem.Key
            };
            _dbContext.CollectionItem.Add(collectionItem);

            if (_processedItemKeys.Contains(zoteroItem.Key))
            {
                return;
            }
            _processedItemKeys.Add(zoteroItem.Key);

            var item = new Item
            {
                ItemId = zoteroItem.Key,
                ItemType = _itemTypes[itemType],
                Title = GetStringValue(zoteroItem.Data, "title"),
                Abstract = GetStringValue(zoteroItem.Data, "abstractNote")
            };

            // set creators
            var creators = new List<string>();
            foreach (var entry in zoteroItem.Data["creators"].EnumerateArray())
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
            if (zoteroItem.Data.TryGetValue("date", out var dateElement) && DateTime.TryParse(dateElement.GetString(), out var dt))
            {
                item.Date = DateOnly.FromDateTime(dt);
            }
            item.DateAdded = zoteroItem.Data["dateAdded"].GetDateTime();
            item.DateModified = zoteroItem.Data["dateModified"].GetDateTime();

            // process tags
            if (zoteroItem.Data.TryGetValue("tags", out var tagsElement))
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

            _dbContext.Add(item);
        }

        private void ProcessItemAttributes(ZoteroItem zoteroItem, string itemType)
        {
            var skipItemFields = new HashSet<string>() { "title", "abstractNote", "extra" };
            var itemTypeFields = _itemTypeFields[itemType];
            foreach (var field in itemTypeFields)
            {
                if (skipItemFields.Contains(field.Key))
                {
                    continue;
                }
                var value = GetStringValue(zoteroItem.Data, field.Key);
                if (value != string.Empty)
                {
                    var itemAttribute = new ItemAttribute
                    {
                        ItemId = zoteroItem.Key,
                        Name = itemTypeFields[field.Key],
                        Value = value
                    };
                    _dbContext.ItemAttribute.Add(itemAttribute);
                }
            }
        }

        private void ProcessNote(ZoteroItem zoteroItem)
        {
            // Ignore stand-alone and already processed notes
            var parentItemKey = GetStringValue(zoteroItem.Data, "parentItem");
            if (parentItemKey == string.Empty || _processedItemKeys.Contains(zoteroItem.Key))
            {
                return;
            }
            _processedItemKeys.Add(zoteroItem.Key);

            var note = new Note
            {
                NoteId = zoteroItem.Key,
                ItemId = parentItemKey,
                Content = GetStringValue(zoteroItem.Data, "note", true) // TODO will an empty note cause this to fail?
            };
            // TODO remove div surrounding content if it exists.
            // Apparently it exists when styles are used.
            _dbContext.Add(note);
        }

        private void ProcessAttachment(ZoteroItem zoteroItem)
        {
            if (_processedItemKeys.Contains(zoteroItem.Key))
            {
                return;
            }
            _processedItemKeys.Add(zoteroItem.Key);

            var attachment = new Attachment
            {
                AttachmentId = zoteroItem.Key,
                ItemId = GetStringValue(zoteroItem.Data, "parentItem", true),
                LinkMode = GetStringValue(zoteroItem.Data, "linkMode", true),
                ContentType = GetStringValue(zoteroItem.Data, "contentType", true),
                Path = GetStringValue(zoteroItem.Data, "path") // not for linked_url
            };
            _dbContext.Attachment.Add(attachment);
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
