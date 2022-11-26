using Hermes.Catalog.API.Entities;

namespace Hermes.Catalog.API.Repositories.Brands;

public class BrandCommandRepository : IBrandCommandRepository
{
    private readonly CatalogContext _catalogContext;

    public BrandCommandRepository(CatalogContext catalogContext) =>
        _catalogContext = catalogContext;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await _catalogContext.SaveChangesAsync(cancellationToken);

    public async Task DeleteAsync(Brand entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            _catalogContext.Brands.Remove(entity);
            await SaveChangesAsync(cancellationToken);
        }
        else _catalogContext.Brands.Remove(entity);
    }

    public async Task DeleteManyAsync(IEnumerable<Brand> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            _catalogContext.Brands.RemoveRange(entities);
            await SaveChangesAsync(cancellationToken);
        }
        else _catalogContext.Brands.RemoveRange(entities);
    }

    public async Task<Brand> InsertAsync(Brand entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            await _catalogContext.Brands.AddAsync(entity, cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }
        else await _catalogContext.Brands.AddAsync(entity, cancellationToken);

        return entity;
    }

    public async Task InsertManyAsync(IEnumerable<Brand> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            await _catalogContext.Brands.AddRangeAsync(entities, cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }
        else await _catalogContext.Brands.AddRangeAsync(entities, cancellationToken);
    }

    public async Task<Brand> UpdateAsync(Brand entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            _catalogContext.Brands.Update(entity);
            await SaveChangesAsync(cancellationToken);
        }
        else _catalogContext.Brands.Update(entity);

        return entity;
    }

    public async Task UpdateManyAsync(IEnumerable<Brand> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            _catalogContext.Brands.UpdateRange(entities);
            await SaveChangesAsync(cancellationToken);
        }
        else _catalogContext.Brands.UpdateRange(entities);
    }
}