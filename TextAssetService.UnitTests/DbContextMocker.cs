using Microsoft.EntityFrameworkCore;
using TextAssetService.Models;

namespace TextAssetService.UnitTests
{
    public static class DbContextMocker
    {
        public static TextAssetDbContext GetTextAssetDbContext(string dbName)
        {
            // Create options for DbContext instance
            var options = new DbContextOptionsBuilder<TextAssetDbContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .Options;

            // Create instance of DbContext
            var dbContext = new TextAssetDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            // Add entities in memory
            dbContext.Seed();

            return dbContext;
        }
    }
}
