namespace Hermes.Catalog.API.Options;

public class BusOptions
{
    public string Host { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string LicensePath { get; set; } = string.Empty;

    public string ConnectionString =>
        $"host={Host};username={Username};password={Password}";
}