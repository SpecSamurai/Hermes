namespace Hermes.Client.Web;

public class ItemGetResponse
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required decimal Price { get; init; }
    public string? PictureFileName { get; init; }
    public string? PictureUri { get; init; }
    public required int AvailableStock { get; init; }
    public required bool OnReorder { get; init; }
    public required Guid TypeId { get; init; }
    public required Guid BrandId { get; init; }
}