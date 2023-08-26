using Hermes.Client.Web.Models.Admin.Brands;
using Hermes.Client.Web.Models.Admin.Items;
using Hermes.Client.Web.Models.Admin.ItemTypes;

namespace Hermes.Client.Web.Models.Admin;

class AdminViewModel
{
    public required BrandsViewModel BrandsViewModel { get; init; }
    public required ItemTypesViewModel ItemTypesViewModel { get; init; }
    public required ItemsViewModel ItemsViewModel { get; init; }
}