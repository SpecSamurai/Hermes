using System.ComponentModel;
using System.Linq.Expressions;
using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.DataStructures;
using Microsoft.EntityFrameworkCore;

namespace Hermes.Catalog.API.Repositories.ItemTypes;

public class ItemTypeQueryRepository : IItemTypeQueryRepository
{
    private readonly CatalogContext _catelogContext;

    public ItemTypeQueryRepository(CatalogContext catelogContext) =>
        _catelogContext = catelogContext;

    public async Task<ItemType?> FindAsync(
        Guid id,
        bool includeDetails = true,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.ItemTypes.SingleOrDefaultAsync(ItemType => ItemType.Id == id, cancellationToken);

    public async Task<List<TResult>> GetListAsync<TResult>(
        IEnumerable<Guid> ids,
        Expression<Func<ItemType, TResult>> selector,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.ItemTypes
                .Where(itemType => ids.Contains(itemType.Id))
                .Select(selector)
                .ToListAsync(cancellationToken);

    public async Task<List<TResult>> GetPageAsync<TResult>(
        Offset offset,
        Expression<Func<ItemType, TResult>> selector,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) where TResult : notnull
    {
        var property = TypeDescriptor.GetProperties(typeof(Item)).Find(sorting, ignoreCase: false);

        var query = property is not null
            ? _catelogContext.ItemTypes.AsNoTracking()
                .OrderBy(brand => property.GetValue(brand))
            : _catelogContext.ItemTypes.AsNoTracking();

        return await query
            .Select(selector)
            .Skip(offset.Skip)
            .Take(offset.Take)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<TResult>> GetPageAsync<TResult>(
        Keyset<ItemType> keyset,
        Expression<Func<ItemType, TResult>> selector,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) where TResult : notnull
    {
        var property = TypeDescriptor.GetProperties(typeof(Item)).Find(sorting, ignoreCase: false);

        var query = property is not null
            ? _catelogContext.ItemTypes.AsNoTracking()
                .OrderBy(brand => property.GetValue(brand))
            : _catelogContext.ItemTypes.AsNoTracking();

        return await query
            .Where(keyset.Predicate)
            .Take(keyset.Take)
            .Select(selector)
            .ToListAsync(cancellationToken);
    }
}