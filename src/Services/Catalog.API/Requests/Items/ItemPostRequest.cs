using System.ComponentModel.DataAnnotations;

namespace Hermes.Catalog.API.Requests.Items;

public class ItemPostRequest
{
    [StringLength(255, ErrorMessage = $"{nameof(Name)} length can't be more than 255.")]
    public string Name { get; set; } = string.Empty;

    [StringLength(512, ErrorMessage = $"{nameof(Description)} length can't be more than 512.")]
    public string? Description { get; set; }

    [StringLength(255, ErrorMessage = $"{nameof(PictureFileName)} length can't be more than 255.")]
    public string? PictureFileName { get; set; }

    [StringLength(255, ErrorMessage = $"{nameof(PictureUri)} length can't be more than 255.")]
    public string? PictureUri { get; set; }

    [Range(0d, double.MaxValue, ErrorMessage = $"{nameof(Price)} value can't be negative.")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = $"{nameof(AvailableStock)} value can't be negative.")]
    public int AvailableStock { get; set; }

    public Guid TypeId { get; set; }
    public Guid BrandId { get; set; }
}