using System.ComponentModel.DataAnnotations;

namespace Hermes.Catalog.API.Entities;

public class Brand : Entity
{
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
}