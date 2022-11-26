using Hermes.Catalog.API.Entities;

namespace Hermes.Catalog.API.Repositories.Items;

public class ItemCommandRepository : IItemCommandRepository
{
    private readonly CatalogContext _catalogContext;

    public ItemCommandRepository(CatalogContext catalogContext) =>
        _catalogContext = catalogContext;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await _catalogContext.SaveChangesAsync(cancellationToken);

    public async Task DeleteAsync(Item entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            _catalogContext.Items.Remove(entity);
            await SaveChangesAsync(cancellationToken);
        }
        else _catalogContext.Items.Remove(entity);
    }

    public async Task DeleteManyAsync(IEnumerable<Item> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            _catalogContext.Items.RemoveRange(entities);
            await SaveChangesAsync(cancellationToken);
        }
        else _catalogContext.Items.RemoveRange(entities);
    }

    public async Task<Item> InsertAsync(Item entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            await _catalogContext.Items.AddAsync(entity, cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }
        else await _catalogContext.Items.AddAsync(entity, cancellationToken);

        return entity;
    }

    public async Task InsertManyAsync(IEnumerable<Item> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            await _catalogContext.Items.AddRangeAsync(entities, cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }
        else await _catalogContext.Items.AddRangeAsync(entities, cancellationToken);
    }

    public async Task<Item> UpdateAsync(Item entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            _catalogContext.Items.Update(entity);
            await SaveChangesAsync(cancellationToken);
        }
        else _catalogContext.Items.Update(entity);

        return entity;
    }

    public async Task UpdateManyAsync(IEnumerable<Item> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            _catalogContext.Items.UpdateRange(entities);
            await SaveChangesAsync(cancellationToken);
        }
        else _catalogContext.Items.UpdateRange(entities);
    }
}