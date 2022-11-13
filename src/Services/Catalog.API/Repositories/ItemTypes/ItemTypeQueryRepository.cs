using System.ComponentModel;
using System.Linq.Expressions;
using Hermes.Catalog.API.Entities;
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

    public async Task<ItemType?> FindAsync(
        Expression<Func<ItemType, bool>> predicate,
        bool includeDetails = true,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.ItemTypes.FirstOrDefaultAsync(predicate, cancellationToken);

    public async Task<ItemType> GetAsync(
        Guid id,
        bool includeDetails = true,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.ItemTypes.SingleAsync(ItemType => ItemType.Id == id, cancellationToken);

    public async Task<ItemType> GetAsync(
        Expression<Func<ItemType, bool>> predicate,
        bool includeDetails = true,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.ItemTypes.FirstAsync(predicate, cancellationToken);

    public async Task<long> GetCountAsync(CancellationToken cancellationToken = default) =>
        await _catelogContext.ItemTypes.LongCountAsync(cancellationToken);

    public async Task<List<ItemType>> GetListAsync(
        bool includeDetails = false,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.ItemTypes.ToListAsync(cancellationToken);

    public async Task<List<ItemType>> GetListAsync(
        Expression<Func<ItemType, bool>> predicate,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.ItemTypes.Where(predicate).ToListAsync(cancellationToken);

    public async Task<List<ItemType>> GetPagedListAsync(
        int skipCount,
        int takeCount,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        var property = TypeDescriptor.GetProperties(typeof(Item)).Find(sorting, ignoreCase: false);

        var query = _catelogContext.ItemTypes.Skip(skipCount).Take(takeCount);

        return property is not null
            ? await query
                .OrderBy(itemType => property.GetValue(itemType))
                .ToListAsync(cancellationToken)
            : await query.ToListAsync(cancellationToken);
    }
}