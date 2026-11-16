using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnergyOptimizer.Data.Models.Entities;

public class Building
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(300)]
    public string Address { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAreaSqM { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }

    public ICollection<Zone> Zones { get; set; } = new List<Zone>();
}
