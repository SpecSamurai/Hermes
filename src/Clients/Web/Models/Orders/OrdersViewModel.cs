using Hermes.Client.Web.Models.Shared;

namespace Hermes.Client.Web.Models.Orders;

internal class OrdersViewModel
{
    public required PaginationViewModel Pagination { get; init; }
    public required IEnumerable<OrderViewModel> Orders { get; init; }
}