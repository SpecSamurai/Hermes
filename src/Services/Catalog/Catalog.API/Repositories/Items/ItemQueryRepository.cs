using System.ComponentModel;
using System.Linq.Expressions;
using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.DataStructures;
using Microsoft.EntityFrameworkCore;

namespace Hermes.Catalog.API.Repositories.Items;

public class ItemQueryRepository : IItemQueryRepository
{
    private readonly CatalogContext _catelogContext;

    public ItemQueryRepository(CatalogContext catelogContext) =>
        _catelogContext = catelogContext;

    public async Task<Item?> FindAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default) =>
        includeDetails
            ? await _catelogContext.Items
                .Include(item => item.Brand)
                .Include(item => item.Type)
                .SingleOrDefaultAsync(item => item.Id == id, cancellationToken)
            : await _catelogContext.Items
                .SingleOrDefaultAsync(item => item.Id == id, cancellationToken);

    public async Task<List<TResult>> GetListAsync<TResult>(
        IEnumerable<Guid> ids,
        Expression<Func<Item, TResult>> selector,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.Items
                .Where(item => ids.Contains(item.Id))
                .Select(selector)
                .ToListAsync(cancellationToken);

    public async Task<List<TResult>> GetPageAsync<TResult>(
        Offset offset,
        Expression<Func<Item, TResult>> selector,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) where TResult : notnull
    {
        var property = TypeDescriptor.GetProperties(typeof(Item)).Find(sorting, ignoreCase: false);

        var query = includeDetails
            ? _catelogContext.Items
                .Include(item => item.Brand)
                .Include(item => item.Type)
                .Skip(offset.Skip)
                .Take(offset.Take)
            : _catelogContext.Items
                .Skip(offset.Skip)
                .Take(offset.Take);

        return property is not null
            ? await query
                .OrderBy(item => property.GetValue(item))
                .Select(selector)
                .ToListAsync(cancellationToken)
            : await query
                .Select(selector)
                .ToListAsync(cancellationToken);
    }

    public async Task<List<TResult>> GetPageAsync<TResult>(
        Keyset<Item> keyset,
        Expression<Func<Item, TResult>> selector,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) where TResult : notnull
    {
        var property = TypeDescriptor.GetProperties(typeof(Item)).Find(sorting, ignoreCase: false);

        var query = includeDetails
            ? _catelogContext.Items
                .Include(item => item.Brand)
                .Include(item => item.Type)
                .Where(keyset.Predicate)
                .Take(keyset.Take)
            : _catelogContext.Items
                .Where(keyset.Predicate)
                .Take(keyset.Take);

        return property is not null
            ? await query
                .OrderBy(item => property.GetValue(item))
                .Select(selector)
                .ToListAsync(cancellationToken)
            : await query
                .Select(selector)
                .ToListAsync(cancellationToken);
    }
}