using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hermes.Catalog.API.Constants;
using Microsoft.EntityFrameworkCore;

namespace Hermes.Catalog.API.Entities;

public class Item : Entity
{
    [MaxLength(256, ErrorMessage = ErrorCodes.Items.InvalidName)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(512, ErrorMessage = ErrorCodes.Items.InvalidDescription)]
    public string? Description { get; set; }

    [Precision(19, 4)]
    public decimal Price { get; set; }

    [MaxLength(256, ErrorMessage = ErrorCodes.Items.InvalidPictureFileName)]
    public string? PictureFileName { get; set; }

    [MaxLength(256, ErrorMessage = ErrorCodes.Items.InvalidPictureUri)]
    public string? PictureUri { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = ErrorCodes.Items.InvalidAvailableStock)]
    public int AvailableStock { get; set; }

    public bool OnReorder { get; set; }

    [ForeignKey(nameof(TypeId))]
    public ItemType? Type { get; set; }
    public Guid TypeId { get; set; }

    [ForeignKey(nameof(BrandId))]
    public Brand? Brand { get; set; }
    public Guid BrandId { get; set; }
}