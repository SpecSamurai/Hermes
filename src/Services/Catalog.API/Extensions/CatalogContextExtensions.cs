using Microsoft.EntityFrameworkCore;

namespace Hermes.Catalog.API.Extensions;

public static class CatalogContextExtensions
{
    public static async Task EnsureInitializedDatabaseAsync(this CatalogContext catalogContext)
    {
        var pendingMigrations = await catalogContext.Database.GetPendingMigrationsAsync();
        if (pendingMigrations.Any())
            await catalogContext.Database.MigrateAsync();

        await catalogContext.Database.EnsureCreatedAsync();
        await catalogContext.SeedAsync();
    }
}