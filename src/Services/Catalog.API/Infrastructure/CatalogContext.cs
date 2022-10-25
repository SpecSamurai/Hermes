using Hermes.Catalog.API.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hermes.Catalog.API.Infrastructure;

public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Item> Items => Set<Item>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<ItemType> ItemTypes => Set<ItemType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var getUtcDateSqlFunction = "getutcdate()";
        var newSequentialIdSqlFunction = "newsequentialid()";

        modelBuilder.Entity<Brand>()
            .Property(brand => brand.Id)
            .HasDefaultValueSql(newSequentialIdSqlFunction);

        modelBuilder.Entity<Brand>()
            .Property(brand => brand.CreatedOn)
            .HasDefaultValueSql(getUtcDateSqlFunction);

        modelBuilder.Entity<Brand>()
            .Property(brand => brand.LastModifiedOn)
            .HasDefaultValueSql(getUtcDateSqlFunction);

        modelBuilder.Entity<ItemType>()
            .Property(brand => brand.Id)
            .HasDefaultValueSql(newSequentialIdSqlFunction);

        modelBuilder.Entity<ItemType>()
            .Property(itemType => itemType.CreatedOn)
            .HasDefaultValueSql(getUtcDateSqlFunction);

        modelBuilder.Entity<ItemType>()
            .Property(itemType => itemType.LastModifiedOn)
            .HasDefaultValueSql(getUtcDateSqlFunction);

        modelBuilder.Entity<Item>()
            .Property(brand => brand.Id)
            .HasDefaultValueSql(newSequentialIdSqlFunction);

        modelBuilder.Entity<Item>()
            .Property(item => item.CreatedOn)
            .HasDefaultValueSql(getUtcDateSqlFunction);

        modelBuilder.Entity<Item>()
            .Property(item => item.LastModifiedOn)
            .HasDefaultValueSql(getUtcDateSqlFunction);
    }
}