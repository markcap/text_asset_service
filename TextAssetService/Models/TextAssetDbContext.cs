using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TextAssetService.Models
{
    public class TextAssetDbContext : DbContext
    {
        public TextAssetDbContext(DbContextOptions<TextAssetDbContext> options) : base(options)
        {
        }
        public DbSet<TextAsset> TextAssets { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<TextAssetGroup> TextAssetGroups { get; set; }
        public DbSet<TextAssetGroupAsset> TextAssetGroupAssets { get; set; }
        public DbSet<Tagging> Tagging { get; set; }
        public DbSet<Tag> Tag { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TextAsset>().HasQueryFilter(t => t.ActiveFlag);
            modelBuilder.Entity<TextAssetGroup>().HasQueryFilter(t => t.ActiveFlag);
            modelBuilder.Entity<TextAssetGroupAsset>().HasQueryFilter(t => t.ActiveFlag);

            SetUpEntity(modelBuilder.Entity<TextAsset>());
            SetUpEntity(modelBuilder.Entity<FileType>());
            SetUpEntity(modelBuilder.Entity<AssetType>());
            SetUpEntity(modelBuilder.Entity<TextAssetGroup>());
            SetUpEntity(modelBuilder.Entity<TextAssetGroupAsset>());
            SetUpEntity(modelBuilder.Entity<Tag>());
            SetUpEntity(modelBuilder.Entity<Tagging>());
            base.OnModelCreating(modelBuilder);
        }

        private void SetUpEntity(EntityTypeBuilder<TextAsset> entity)
        {
            entity.HasIndex(f => f.ActiveFlag);
            entity.HasIndex(f => f.FeatureId);
            entity.HasIndex(f => f.FileName);
            entity.HasIndex(f => f.IssueDate);
            entity.HasIndex(f => f.OriginalDate);
            entity.HasIndex(f => f.TextAssetUuid).IsUnique();
        }

        private void SetUpEntity(EntityTypeBuilder<FileType> entity)
        {
            entity.HasIndex(f => f.MimeType).IsUnique();
            entity.HasIndex(f => f.ActiveFlag);
        }
        private void SetUpEntity(EntityTypeBuilder<AssetType> entity)
        {
            entity.HasIndex(f => f.AssetTypeName).IsUnique();
            entity.HasIndex(f => f.ActiveFlag);
        }

        private void SetUpEntity(EntityTypeBuilder<TextAssetGroup> entity)
        {
            entity.HasIndex(f => f.FeatureId);
            entity.HasIndex(f => f.PublishDate);
            entity.HasIndex(f => f.ActiveFlag);
        }
        private void SetUpEntity(EntityTypeBuilder<TextAssetGroupAsset> entity)
        {
            entity.HasIndex(f => f.ActiveFlag);
        }
        private void SetUpEntity(EntityTypeBuilder<Tag> entity)
        {
            entity.HasIndex(t => t.TagName)
                  .IsUnique();
            entity.Property(t => t.ActiveFlag).HasDefaultValue(true);
            entity.HasIndex(t => t.ActiveFlag);
            entity.HasQueryFilter(t => (bool)t.ActiveFlag);
        }

        private void SetUpEntity(EntityTypeBuilder<Tagging> entity)
        {
            entity.HasIndex(t => new { t.TaggableId, t.TaggableType, t.Context });
            entity.Property(t => t.ActiveFlag).HasDefaultValue(true);
            entity.HasIndex(t => t.ActiveFlag);
            entity.HasQueryFilter(t => (bool)t.ActiveFlag);
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is ITrackable trackable)
                {
                    var now = DateTime.UtcNow;
                    var user = GetCurrentUser();
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.ModifiedDate = now;
                            trackable.ModifiedBy = user;
                            break;

                        case EntityState.Added:
                            trackable.CreatedDate = now;
                            trackable.CreatedBy = user;
                            trackable.ModifiedDate = now;
                            trackable.ModifiedBy = user;
                            break;
                    }
                }
            }
        }

        private string GetCurrentUser()
        {
            return "SystemUser"; // TODO implement logic when admin users are added to new services
        }
    }
}
