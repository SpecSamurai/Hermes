namespace Hermes.Catalog.API.Responses;

public class ItemGetResponse
{
    public required string Name { get; init; }
    public required string? Description { get; init; }
    public required decimal Price { get; init; }
    public required string? PictureFileName { get; init; }
    public required string? PictureUri { get; init; }
    public required int AvailableStock { get; init; }
    public required bool OnReorder { get; init; }
    public required Guid TypeId { get; init; }
    public ItemTypeGetResponse? Type { get; init; }
    public required Guid BrandId { get; init; }
    public BrandGetResponse? Brand { get; init; }
}