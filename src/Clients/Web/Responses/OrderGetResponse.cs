namespace Hermes.Client.Web;

public class OrderGetResponse
{
    public required Guid Id { get; init; }
    public required IEnumerable<OrderedProductGetResponse> Products { get; init; }
    public required decimal Price { get; init; }
    public required DateTime Date { get; init; }
    public required string Status { get; init; }
}