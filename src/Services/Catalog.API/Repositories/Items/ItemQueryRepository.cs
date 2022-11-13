using System.ComponentModel;
using System.Linq.Expressions;
using Hermes.Catalog.API.Entities;
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

    public async Task<Item?> FindAsync(
        Expression<Func<Item, bool>> predicate,
        bool includeDetails = true,
        CancellationToken cancellationToken = default) =>
            includeDetails
                ? await _catelogContext.Items
                    .Include(item => item.Brand)
                    .Include(item => item.Type)
                    .FirstOrDefaultAsync(predicate, cancellationToken)
                : await _catelogContext.Items
                    .FirstOrDefaultAsync(predicate, cancellationToken);

    public async Task<Item> GetAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default) =>
        includeDetails
            ? await _catelogContext.Items
                .Include(item => item.Brand)
                .Include(item => item.Type)
                .SingleAsync(item => item.Id == id, cancellationToken)
            : await _catelogContext.Items
                .SingleAsync(item => item.Id == id, cancellationToken);

    public async Task<Item> GetAsync(
        Expression<Func<Item, bool>> predicate,
        bool includeDetails = true,
        CancellationToken cancellationToken = default) =>
            includeDetails
                ? await _catelogContext.Items
                    .Include(item => item.Brand)
                    .Include(item => item.Type)
                    .FirstAsync(predicate, cancellationToken)
                : await _catelogContext.Items
                    .FirstAsync(predicate, cancellationToken);

    public async Task<long> GetCountAsync(CancellationToken cancellationToken = default) =>
        await _catelogContext.Items.LongCountAsync(cancellationToken);

    public async Task<List<Item>> GetListAsync(
        bool includeDetails = false,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.Items.ToListAsync(cancellationToken);

    public async Task<List<Item>> GetListAsync(
        Expression<Func<Item, bool>> predicate,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.Items.Where(predicate).ToListAsync(cancellationToken);

    public async Task<List<Item>> GetPagedListAsync(
        int skipCount,
        int takeCount,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        var property = TypeDescriptor.GetProperties(typeof(Item)).Find(sorting, ignoreCase: false);

        var query = includeDetails
            ? _catelogContext.Items
                .Include(item => item.Brand)
                .Include(item => item.Type)
                .Skip(skipCount)
                .Take(takeCount)
            : _catelogContext.Items
                .Skip(skipCount)
                .Take(takeCount);

        return property is not null
            ? await query
                .OrderBy(item => property.GetValue(item))
                .ToListAsync(cancellationToken)
            : await query.ToListAsync(cancellationToken);
    }
}