namespace Hermes.Client.Web.Options;

public class BasketApiOptions
{
    public required string BaseAddress { get; init; }
    public required string GetBasketEndpointPath { get; init; }
    public required string Hub { get; init; }
}