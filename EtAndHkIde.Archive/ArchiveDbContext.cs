using EtAndHkIde.Archive.Models;
using Microsoft.EntityFrameworkCore;

namespace EtAndHkIde.Archive
{
    public class ArchiveDbContext : DbContext
    {
        public ArchiveDbContext(DbContextOptions<ArchiveDbContext> options) : base(options) { }

        public DbSet<Collection> Collection => Set<Collection>();
        public DbSet<Item> Item => Set<Item>();
        public DbSet<Models.ItemAttribute> ItemAttribute => base.Set<Models.ItemAttribute>();
        public DbSet<CollectionItem> CollectionItem => Set<CollectionItem>();
        public DbSet<Note> Note => Set<Note>();
        public DbSet<Attachment> Attachment => Set<Attachment>();
    }
}
