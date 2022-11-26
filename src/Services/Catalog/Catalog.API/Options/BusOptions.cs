namespace Hermes.Catalog.API.Options;

public class BusOptions
{
    public required string Host { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required string EndpointName { get; init; }
    public required string LicensePath { get; init; }

    public string ConnectionString =>
        $"host={Host};username={Username};password={Password}";
}