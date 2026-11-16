using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolEnergyOptimizer.Data.Models.Enums;

namespace SchoolEnergyOptimizer.Data.Models.Entities;

public class Zone
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public int Floor { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal AreaSqM { get; set; }

    public ZoneType ZoneType { get; set; }

    public Guid BuildingId { get; set; }

    public Building Building { get; set; } = null!;

    public ICollection<MeterPoint> MeterPoints { get; set; } = new List<MeterPoint>();
}
