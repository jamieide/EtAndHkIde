using EtAndHkIde.CLI.Zotero;
using System;
using System.Collections.Generic;
using System.Text;

namespace EtAndHkIde.CLI.Sqlite
{
    internal class ZoteroImportService
    {
        private readonly ZoteroLocalApiService _zotero;
        private readonly EtAndHkIdeDbContext _dbContext;

        private IDictionary<string, string> _localizedFields;
        private HashSet<string> _processedItemKeys = [];

        public ZoteroImportService(ZoteroLocalApiService zotero, EtAndHkIdeDbContext dbContext)
        {
            _zotero = zotero;
            _dbContext = dbContext;
        }

        public async Task ExecuteAsync(string topCollectionKey)
        {
            _localizedFields = await _zotero.GetItemFieldsAsync();

            var topCollection = await _zotero.GetCollection(topCollectionKey);
            await ProcessCollection(topCollection);
        }

        private async Task ProcessCollection(Collection collection)
        {
            var dbCollection = new DbCollection
            {
                CollectionId = collection.Key,
                Name = collection.Name
            };
            _dbContext.Collection.Add(dbCollection);
            await ProcessCollectionItems(collection);
            _dbContext.SaveChanges();
            _dbContext.ChangeTracker.Clear();

            var subCollections = await _zotero.GetSubCollectionsAsync(collection.Key);
            foreach (var subCollection in subCollections)
            {
                await ProcessCollection(subCollection);
            }
        }

        private async Task ProcessCollectionItems(Collection collection)
        {
            var zoteroItems = await _zotero.GetItemsByCollectionAsync(collection.Key);

            foreach (var zoteroItem in zoteroItems)
            {
                switch (zoteroItem)
                {
                    case Item item:
                        ProcessItem(collection, item);
                        break;
                    case Note note:
                        ProcessNote(note);
                        break;
                    case Attachment attachment:
                        ProcessAttachment(attachment);
                        break;
                    default:
                        throw new Exception($"Unhandled type '{zoteroItem.GetType()}'.");
                }

                // Add tags
                var tags = zoteroItem.Tags
                    .Select(x => new DbItemTag
                    {
                        ItemId = zoteroItem.Key,
                        Value = x
                    }).ToList();
                _dbContext.ItemTag.AddRange(tags);

            }

        }

        private void ProcessItem(Collection collection, Item item)
        {
            // Add relationship to collection
            var dbConnectionItem = new DbCollectionItem
            {
                CollectionId = collection.Key,
                ItemId = item.Key
            };
            _dbContext.Add(dbConnectionItem);

            if (_processedItemKeys.Contains(item.Key))
            {
                return;
            }

            var dbItem = new DbItem
            {
                ItemId = item.Key,
                Title = item.Title,
                Abstract = item.Abstract
            };
            _dbContext.Add(dbItem);

            // TODO localize names
            var dbAttributes = item.Attributes
                .Select(x => new DbItemAttribute
                {
                    ItemId = item.Key,
                    Name = _localizedFields.TryGetValue(x.Name, out var value) ? value : x.Name,
                    Value = x.Value
                });
            _dbContext.ItemAttribute.AddRange(dbAttributes);
            _processedItemKeys.Add(item.Key);
        }

        private void ProcessNote(Note note)
        {
            // Ignore stand-alone and already processed notes
            if (string.IsNullOrEmpty(note.ParentItemKey) || _processedItemKeys.Contains(note.Key))
            {
                return;
            }
            _processedItemKeys.Add(note.Key);

            var dbNote = new DbNote
            {
                NoteId = note.Key,
                ItemId = note.ParentItemKey,
                Content = note.Content
            };
            // TODO remove div surrounding content if it exists.
            // Apparently it exists when styles are used.
            _dbContext.Add(dbNote);
        }

        private void ProcessAttachment(Attachment attachment)
        {
            if (_processedItemKeys.Contains(attachment.Key))
            {
                return;
            }
            _processedItemKeys.Add(attachment.Key);

            var dbAttachment = new DbAttachment
            {
                AttachmentId = attachment.Key,
                ItemId = attachment.ParentItemKey,
                LinkMode = attachment.LinkMode,
                ContentType = attachment.ContentType,
                Path = attachment.Path
            };
            _dbContext.Attachment.Add(dbAttachment);
        }
    }
}
