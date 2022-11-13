namespace Hermes.Catalog.API.Responses;

public class ItemGetResponse
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public string? PictureFileName { get; set; }
    public string? PictureUri { get; set; }
    public int AvailableStock { get; set; }
    public bool OnReorder { get; set; }
    public Guid TypeId { get; set; }
    public ItemTypeGetResponse? Type { get; set; }
    public Guid BrandId { get; set; }
    public BrandGetResponse? Brand { get; set; }
}