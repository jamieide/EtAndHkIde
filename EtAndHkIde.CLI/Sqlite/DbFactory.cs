using EtAndHkIde.CLI.Zotero;

namespace EtAndHkIde.CLI.Sqlite
{
    internal static class DbFactory
    {
        public static DbCollection BuildDbCollection(Collection collection)
        {
            return new DbCollection
            {
                CollectionId = collection.Key,
                Name = collection.Name
            };
        }

        public static DbItem BuildDbItem(Item item)
        {
            return new DbItem
            {
                ItemId = item.Key,
                Title = item.Title,
                Abstract = item.Abstract
            };
        }

    }
}
