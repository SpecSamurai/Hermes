using System.ComponentModel;
using System.Linq.Expressions;
using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.DataStructures;
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

    public async Task<List<TResult>> GetListAsync<TResult>(
        IEnumerable<Guid> ids,
        Expression<Func<Brand, TResult>> selector,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) =>
            await _catelogContext.Brands
                .Where(brand => ids.Contains(brand.Id))
                .Select(selector)
                .ToListAsync(cancellationToken);

    public async Task<IList<TResult>> GetPageAsync<TResult>(
       Offset offset,
       Expression<Func<Brand, TResult>> selector,
       string sorting,
       bool includeDetails = false,
       CancellationToken cancellationToken = default) where TResult : notnull
    {
        var property = TypeDescriptor.GetProperties(typeof(Item)).Find(sorting, ignoreCase: false);

        var query = property is not null
            ? _catelogContext.Brands.AsNoTracking()
                .OrderBy(brand => property.GetValue(brand))
            : _catelogContext.Brands.AsNoTracking();

        return await query
            .Select(selector)
            .Skip(offset.Skip)
            .Take(offset.Take)
            .ToListAsync(cancellationToken);
    }

    public async Task<IList<TResult>> GetPageAsync<TResult>(
        Keyset<Brand> keyset,
        Expression<Func<Brand, TResult>> selector,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default) where TResult : notnull
    {
        var property = TypeDescriptor.GetProperties(typeof(Item)).Find(sorting, ignoreCase: false);

        var query = property is not null
            ? _catelogContext.Brands.AsNoTracking()
                .OrderBy(brand => property.GetValue(brand))
            : _catelogContext.Brands.AsNoTracking();

        return await query
            .Where(keyset.Predicate)
            .Take(keyset.Take)
            .Select(selector)
            .ToListAsync(cancellationToken);
    }
}