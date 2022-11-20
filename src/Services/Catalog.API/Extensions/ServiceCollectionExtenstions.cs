using System.Data.SqlClient;
using Hermes.Catalog.API;
using Hermes.Catalog.API.Options;
using Hermes.Catalog.API.Repositories.Brands;
using Hermes.Catalog.API.Repositories.Items;
using Hermes.Catalog.API.Repositories.ItemTypes;
using Microsoft.EntityFrameworkCore;
using NServiceBus.Persistence.Sql;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtenstions
{
    public static IServiceCollection AddDbContext(this IServiceCollection serviceCollection, IWebHostEnvironment environment) =>
        serviceCollection.AddScoped<CatalogContext>(serviceProvider =>
        {
            var sqlStorageSession = serviceProvider.GetRequiredService<ISqlStorageSession>();
            var connectionString = serviceProvider
                .GetRequiredService<IConfiguration>()
                .GetConnectionString(nameof(CatalogContext));

            var optionsBuilder = new DbContextOptionsBuilder<CatalogContext>()
                .UseSqlServer(
                    sqlStorageSession.Connection ?? new SqlConnection(connectionString),
                    sqlServerOptions =>
                    {
                        sqlServerOptions.MigrationsAssembly(typeof(Program).Assembly.FullName);
                        // sqlServerOptions.EnableRetryOnFailure();
                    }
                );

            if (environment.IsDevelopment())
            {
                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.EnableSensitiveDataLogging();
            }

            var catalogContext = new CatalogContext(optionsBuilder.Options);
            catalogContext.Database.UseTransaction(sqlStorageSession.Transaction);

            sqlStorageSession.OnSaveChanges(
                (_, cancellationToken) => catalogContext.SaveChangesAsync(cancellationToken));

            return catalogContext;
        });

    public static IServiceCollection AddCustomOptions(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddOptions<MigrationOptions>()
            .Configure<IConfiguration>((settings, configuration) =>
                configuration
                    .GetSection(nameof(MigrationOptions))
                    .Bind(settings))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        serviceCollection
            .AddOptions<BusOptions>()
            .Configure<IConfiguration>((settings, configuration) =>
                configuration
                    .GetSection(nameof(BusOptions))
                    .Bind(settings))
            .ValidateDataAnnotations()
            .ValidateOnStart();

        return serviceCollection;
    }

    public static IServiceCollection AddDependencies(this IServiceCollection serviceCollection) =>
        serviceCollection
            .AddScoped<IItemQueryRepository, ItemQueryRepository>()
            .AddScoped<IItemCommandRepository, ItemCommandRepository>()
            .AddScoped<IBrandQueryRepository, BrandQueryRepository>()
            .AddScoped<IBrandCommandRepository, BrandCommandRepository>()
            .AddScoped<IItemTypeQueryRepository, ItemTypeQueryRepository>()
            .AddScoped<IItemTypeCommandRepository, ItemTypeCommandRepository>();
}