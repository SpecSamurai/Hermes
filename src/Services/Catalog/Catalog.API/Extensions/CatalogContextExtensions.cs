using Microsoft.EntityFrameworkCore;

namespace Hermes.Catalog.API.Extensions;

public static class CatalogContextExtensions
{
    public static async Task EnsureInitializedDatabaseAsync(this WebApplication webApplication)
    {
        var connectionString = webApplication.Configuration.GetConnectionString(nameof(CatalogContext));
        var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>().UseSqlServer(connectionString);
        using var catalogContext = new CatalogContext(optionsBuilder.Options);

        var pendingMigrations = await catalogContext.Database.GetPendingMigrationsAsync();
        if (pendingMigrations.Any())
            await catalogContext.Database.MigrateAsync();

        await catalogContext.Database.EnsureCreatedAsync();
        await catalogContext.SeedAsync();
    }
}