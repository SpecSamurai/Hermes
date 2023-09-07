using Fintech;

namespace Hermes.Client.Web.Requests;

public class CreateItemRequest
{
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required Money Price { get; init; }
    public string? PictureUri { get; init; }
    public required int AvailableStock { get; init; }
    public required Guid TypeId { get; init; }
    public required Guid BrandId { get; init; }
}