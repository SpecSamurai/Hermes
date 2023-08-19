namespace Hermes.Client.Web.Models.Error;

public class ErrorViewModel
{
    public string StatusCode { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;

    public string PageTitleSuffix =>
        ShowStatusCode ? $" - {StatusCode}" : string.Empty;

    public bool ShowStatusCode =>
        string.IsNullOrWhiteSpace(StatusCode) is false;
}