using System.ComponentModel;
using System.Linq.Expressions;
using Hermes.Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hermes.Catalog.API.Repositories.Brands;

public class BrandQueryRepository : IBrandQueryRepository
{
    private readonly CatalogContext _catelogContext;

    public BrandQueryRepository(CatalogContext catelogContext) =>
        _catelogContext = catelogContext;

    public async Task<Brand?> FindAsync(
        Guid id,
        bool includeDetails = true,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.Brands.SingleOrDefaultAsync(Brand => Brand.Id == id, cancellationToken);

    public async Task<Brand?> FindAsync(
        Expression<Func<Brand, bool>> predicate,
        bool includeDetails = true,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.Brands.FirstOrDefaultAsync(predicate, cancellationToken);

    public async Task<Brand> GetAsync(
        Guid id,
        bool includeDetails = true,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.Brands.SingleAsync(Brand => Brand.Id == id, cancellationToken);

    public async Task<Brand> GetAsync(
        Expression<Func<Brand, bool>> predicate,
        bool includeDetails = true,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.Brands.FirstAsync(predicate, cancellationToken);

    public async Task<long> GetCountAsync(CancellationToken cancellationToken = default) =>
        await _catelogContext.Brands.LongCountAsync(cancellationToken);

    public async Task<List<Brand>> GetListAsync(
        bool includeDetails = false,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.Brands.ToListAsync(cancellationToken);

    public async Task<List<Brand>> GetListAsync(
        Expression<Func<Brand, bool>> predicate,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.Brands.Where(predicate).ToListAsync(cancellationToken);

    public async Task<List<Brand>> GetPagedListAsync(
        int skipCount,
        int takeCount,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        var property = TypeDescriptor.GetProperties(typeof(Item)).Find(sorting, ignoreCase: false);

        var query = _catelogContext.Brands.Skip(skipCount).Take(takeCount);

        return property is not null
            ? await query
                .OrderBy(brand => property.GetValue(brand))
                .ToListAsync(cancellationToken)
            : await query.ToListAsync(cancellationToken);
    }
}