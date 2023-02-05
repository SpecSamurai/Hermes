namespace Hermes.Client.Web.Configurations;

public class PaginationViewConfiguration
{
    public required int MaxAdditionalPages { get; init; }
    public required string PageUrl { get; init; }
}