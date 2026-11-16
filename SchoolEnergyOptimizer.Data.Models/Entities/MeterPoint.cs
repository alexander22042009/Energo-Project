using System.ComponentModel.DataAnnotations;
using SchoolEnergyOptimizer.Data.Models.Enums;

namespace SchoolEnergyOptimizer.Data.Models.Entities;

public class MeterPoint
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string SerialNumber { get; set; } = string.Empty;

    public EnergyType EnergyType { get; set; }

    public bool IsActive { get; set; } = true;

    public Guid ZoneId { get; set; }

    public Zone Zone { get; set; } = null!;

    public ICollection<Reading> Readings { get; set; } = new List<Reading>();

    public ICollection<AnomalyAlert> AnomalyAlerts { get; set; } = new List<AnomalyAlert>();
}
