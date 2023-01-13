namespace Hermes.Catalog.API.Responses;

public record PageResponse<TModel>
{
    public required IEnumerable<TModel> Data { get; init; }
    public required int PageIndex { get; init; }
    public required int PageSize { get; init; }
}