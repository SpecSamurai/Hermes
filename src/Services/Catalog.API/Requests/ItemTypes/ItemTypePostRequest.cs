using System.ComponentModel.DataAnnotations;

namespace Hermes.Catalog.API.Requests.ItemTypes;

public class ItemTypePostRequest
{
    [StringLength(255, ErrorMessage = $"{nameof(Name)} length can't be more than 255.")]
    public string Name { get; set; } = string.Empty;
}