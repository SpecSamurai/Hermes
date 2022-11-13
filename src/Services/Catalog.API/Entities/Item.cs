using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hermes.Catalog.API.Entities;

public class Item : Entity
{
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(512)]
    public string? Description { get; set; }

    [Precision(10, 2)]
    public decimal Price { get; set; }

    [MaxLength(255)]
    public string? PictureFileName { get; set; }

    [MaxLength(255)]
    public string? PictureUri { get; set; }

    [Range(0, int.MaxValue)]
    public int AvailableStock { get; set; }

    public bool OnReorder { get; set; }

    [ForeignKey(nameof(TypeId))]
    public ItemType? Type { get; set; }
    public Guid TypeId { get; set; }

    [ForeignKey(nameof(BrandId))]
    public Brand? Brand { get; set; }
    public Guid BrandId { get; set; }
}