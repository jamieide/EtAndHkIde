using Microsoft.EntityFrameworkCore;

namespace EtAndHkIde.CLI.Sqlite
{
    internal class EtAndHkIdeDbContext : DbContext
    {
        public EtAndHkIdeDbContext(DbContextOptions<EtAndHkIdeDbContext> options) : base(options) { }

        public DbSet<DbCollection> Collection => Set<DbCollection>();
        public DbSet<DbItem> Item => Set<DbItem>();
        public DbSet<DbItemAttribute> ItemAttribute => Set<DbItemAttribute>();
        public DbSet<DbItemTag> ItemTag => Set<DbItemTag>();
        public DbSet<DbCollectionItem> CollectionItem => Set<DbCollectionItem>();
        public DbSet<DbNote> Note => Set<DbNote>();
        public DbSet<DbAttachment> Attachment => Set<DbAttachment>();

    }
}
