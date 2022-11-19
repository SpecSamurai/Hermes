using System.ComponentModel.DataAnnotations;

namespace Hermes.Catalog.API.Requests.ItemTypes;

public class ItemTypePatchRequest
{
    [StringLength(128, ErrorMessage = $"{nameof(Name)} length must be less or equal 128.")]
    public string Name { get; set; } = string.Empty;
}