using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.Query;

namespace Hermes.Catalog.API.Repositories.ItemTypes;

public interface IItemTypeQueryRepository :
    IGetByIdNullableQueryRepository<Guid, ItemType>,
    IListByIdQueryRepository<Guid, ItemType>,
    IPaginationQueryRepository<ItemType>
{
}