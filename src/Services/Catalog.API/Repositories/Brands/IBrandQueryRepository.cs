using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.Query;

namespace Hermes.Catalog.API.Repositories.Brands;

public interface IBrandQueryRepository :
    IGetByIdQueryRepository<Guid, Brand>,
    IGetByPredicateQueryRepository<Brand>,
    IListQueryRepository<Brand>
{
}