namespace Hermes.Basket.API.Commands;

public record CustomerCheckoutAcceptedCommand : ICommand
{
    public  string UserId { get; init; }
    public  string UserName { get; init; }
    public int OrderNumber { get; init; }
    public required string City { get; init; }
    public required string Street { get; init; }
    public required string State { get; init; }
    public required string Country { get; init; }
    public required string ZipCode { get; init; }
    public required string CardNumber { get; init; }
    public required string CardHolderName { get; init; }
    public DateTime CardExpiration { get; init; }
    public required string CardSecurityNumber { get; init; }
    public int CardTypeId { get; init; }
    public required string Buyer { get; init; }
    public Guid RequestId { get; init; }
    public  CustomerCheckoutBasket Basket { get; init; }
}