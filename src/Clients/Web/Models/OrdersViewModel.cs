namespace Hermes.Client.Web.Models;

internal class OrdersViewModel
{
    public required IEnumerable<OrderViewModel> Orders { get; init; }
}