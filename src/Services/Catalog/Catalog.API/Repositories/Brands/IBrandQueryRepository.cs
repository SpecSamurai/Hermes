using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.Query;

namespace Hermes.Catalog.API.Repositories.Brands;

public interface IBrandQueryRepository :
    IGetByIdNullableQueryRepository<Guid, Brand>,
    IListByIdQueryRepository<Guid, Brand>,
    IPaginationQueryRepository<Brand>
{
}