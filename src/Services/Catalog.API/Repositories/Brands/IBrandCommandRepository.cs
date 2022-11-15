using Hermes.Catalog.API.Entities;
using Hermes.Frameworks.Repositories.Command;

namespace Hermes.Catalog.API.Repositories.Brands;

public interface IBrandCommandRepository :
    IInsertCommandRepository<Brand>,
    IUpdateCommandRepository<Brand>,
    IDeleteByEntityCommandRepository<Brand>
{
}