using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.Query;

namespace Hermes.Catalog.API.Repositories.ItemTypes;

public interface IItemTypeQueryRepository :
    IGetByIdNullableQueryRepository<Guid, ItemType>,
    IListQueryRepository<ItemType>,
    IPaginationQueryRepository<ItemType>
{
}