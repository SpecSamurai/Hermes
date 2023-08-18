namespace Hermes.Client.Web.Options;

public class OrderingApiOptions
{
    public required string BaseAddress { get; init; }
    public required string OrdersEndpointPath { get; init; }
}