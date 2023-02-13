namespace Hermes.Client.Web.Models.Shared;

public class PaginationViewModel
{
    public required int PageIndex { get; init; }
    public required int TotalPages { get; init; }
    public required int MaxAdditionalPages { get; init; }
    public required string PageUrl { get; init; }
}