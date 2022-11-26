using Hermes.Catalog.API.Entities;

namespace Hermes.Catalog.API.Repositories.ItemTypes;

public class ItemTypeCommandRepository : IItemTypeCommandRepository
{
    private readonly CatalogContext _catalogContext;

    public ItemTypeCommandRepository(CatalogContext catalogContext) =>
        _catalogContext = catalogContext;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default) =>
        await _catalogContext.SaveChangesAsync(cancellationToken);

    public async Task DeleteAsync(ItemType entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            _catalogContext.ItemTypes.Remove(entity);
            await SaveChangesAsync(cancellationToken);
        }
        else _catalogContext.ItemTypes.Remove(entity);
    }

    public async Task DeleteManyAsync(IEnumerable<ItemType> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            _catalogContext.ItemTypes.RemoveRange(entities);
            await SaveChangesAsync(cancellationToken);
        }
        else _catalogContext.ItemTypes.RemoveRange(entities);
    }

    public async Task<ItemType> InsertAsync(ItemType entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            await _catalogContext.ItemTypes.AddAsync(entity, cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }
        else await _catalogContext.ItemTypes.AddAsync(entity, cancellationToken);

        return entity;
    }

    public async Task InsertManyAsync(IEnumerable<ItemType> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            await _catalogContext.ItemTypes.AddRangeAsync(entities, cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }
        else await _catalogContext.ItemTypes.AddRangeAsync(entities, cancellationToken);
    }

    public async Task<ItemType> UpdateAsync(ItemType entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            _catalogContext.ItemTypes.Update(entity);
            await SaveChangesAsync(cancellationToken);
        }
        else _catalogContext.ItemTypes.Update(entity);

        return entity;
    }

    public async Task UpdateManyAsync(IEnumerable<ItemType> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        if (autoSave)
        {
            _catalogContext.ItemTypes.UpdateRange(entities);
            await SaveChangesAsync(cancellationToken);
        }
        else _catalogContext.ItemTypes.UpdateRange(entities);
    }
}