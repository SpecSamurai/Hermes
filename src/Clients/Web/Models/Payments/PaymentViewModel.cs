namespace Hermes.Client.Web.Models.Payments;

class PaymentViewModel
{
    public required Guid Id { get; init; }
    public required Guid OrderId { get; init; }
    public required decimal Price { get; init; }
    public required DateTime Date { get; init; }
    public required string Status { get; init; }
}