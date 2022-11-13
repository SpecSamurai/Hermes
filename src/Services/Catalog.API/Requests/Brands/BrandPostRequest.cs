using System.ComponentModel.DataAnnotations;

namespace Hermes.Catalog.API.Requests.Brands;

public class BrandPostRequest
{
    [StringLength(255, ErrorMessage = $"{nameof(Name)} length can't be more than 255.")]
    public string Name { get; set; } = string.Empty;
}