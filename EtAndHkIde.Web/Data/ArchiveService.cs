using EtAndHkIde.Archive;
using EtAndHkIde.Archive.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EtAndHkIde.Web.Data
{

    // TODO this belongs in Web project using view models
    public class ArchiveService
    {
        private readonly ArchiveDbContext _dbContext;

        public ArchiveService(ArchiveDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Collection>> GetRootCollections()
        {
            return await _dbContext.Collection
                .Where(x => x.Key == x.ParentKey)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<Collection>> GetSubCollections(string key)
        {
            return await _dbContext.Collection
                .Where(x => x.Key != x.ParentKey && x.ParentKey == key.ToUpper())
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<List<Item>> GetItemsByCollection(string key)
        {
            return await _dbContext.CollectionItem
                .Where(x => x.Collection.Key == key.ToUpper())
                .Select(x => x.Item)
                .ToListAsync();
        }

        public async Task<Item> GetItem(string key)
        {
            return await _dbContext.Item
                .Where(x => x.Key == key.ToUpper())
                .Include(x => x.Attributes)
                .Include(x => x.Notes)
                .SingleOrDefaultAsync();
        }
    }
}
