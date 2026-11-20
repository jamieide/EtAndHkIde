using EtAndHkIde.Archive.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EtAndHkIde.Archive
{
    public class ArchiveService
    {
        private readonly ArchiveDbContext _dbContext;

        public ArchiveService(ArchiveDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Collection> GetCollections()
        {
            return _dbContext.Collection.ToList();
        }
    }
}
