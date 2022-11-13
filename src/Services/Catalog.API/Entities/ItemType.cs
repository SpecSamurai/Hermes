using System.ComponentModel.DataAnnotations;
using Hermes.Catalog.API.Constants;

namespace Hermes.Catalog.API.Entities;

public class ItemType : Entity
{
    [MaxLength(255, ErrorMessage = ErrorCodes.ItemTypes.InvalidName)]
    public string Name { get; set; } = string.Empty;
}