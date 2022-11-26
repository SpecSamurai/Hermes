using System.ComponentModel.DataAnnotations;

namespace Hermes.Catalog.API.Requests.ItemTypes;

public class ItemTypePatchRequest
{
    [Required]
    [StringLength(128, ErrorMessage = $"{nameof(Name)} length must be less or equal 128.")]
    public required string Name { get; set; }
}