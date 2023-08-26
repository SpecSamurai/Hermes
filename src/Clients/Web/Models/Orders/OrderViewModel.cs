namespace Hermes.Client.Web.Models.Orders;

class OrderViewModel
{
    public required Guid Id { get; init; }
    public required IEnumerable<OrderedProductViewModel> Products { get; init; }
    public required decimal Price { get; init; }
    public required DateTime Date { get; init; }
    public required string Status { get; init; }
}