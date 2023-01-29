namespace Hermes.Client.Web.Models.Shared;

public class PaginationViewModel
{
    public required int PageIndex { get; init; }
    public required int TotalPages { get; init; }
    public required int NextPagesCount { get; init; }

    public required string PageUrl { get; init; }
    public required string PreviousButtonLabel { get; init; }
    public required string NextButtonLabel { get; init; }
}