using System.ComponentModel.DataAnnotations;

namespace Hermes.Catalog.API.Requests.Items;

public class ItemPostRequest
{
    [Required]
    [StringLength(128, ErrorMessage = $"{nameof(Name)} length must be less or equal 128.")]
    public required string Name { get; set; }

    [StringLength(512, ErrorMessage = $"{nameof(Description)} length must be less or equal 512.")]
    public string? Description { get; set; }

    [StringLength(128, ErrorMessage = $"{nameof(PictureFileName)} length must be less or equal 128.")]
    public string? PictureFileName { get; set; }

    [StringLength(256, ErrorMessage = $"{nameof(PictureUri)} length must be less or equal 256.")]
    public string? PictureUri { get; set; }

    [Required]
    [Range(0d, double.MaxValue, ErrorMessage = $"{nameof(Price)} value must be greater or equal 0.")]
    public required decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = $"{nameof(AvailableStock)} value must be greater or equal 0.")]
    public int AvailableStock { get; set; }

    [Required]
    public required Guid TypeId { get; set; }

    [Required]
    public required Guid BrandId { get; set; }
}