using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hermes.Catalog.API.Entities;

public abstract class Entity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    [MaxLength(255)]
    public string CreatedBy { get; set; } = string.Empty;

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime LastModifiedOn { get; set; }

    [MaxLength(255)]
    public string LastModifiedBy { get; set; } = string.Empty;

    [Timestamp]
    public byte[] RowVersion { get; set; } = { };
}