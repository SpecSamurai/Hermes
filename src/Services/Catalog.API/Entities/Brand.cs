using System.ComponentModel.DataAnnotations;
using Hermes.Catalog.API.Constants;

namespace Hermes.Catalog.API.Entities;

public class Brand : Entity
{
    [MaxLength(256, ErrorMessage = ErrorCodes.Brands.InvalidName)]
    public string Name { get; set; } = string.Empty;
}