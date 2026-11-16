using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolEnergyOptimizer.Data.Models.Entities;

public class AnomalyAlert
{
    public Guid Id { get; set; }

    public DateTime DetectedOn { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal MeasuredValue { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal ExpectedBaselineValue { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal DeviationPercentage { get; set; }

    [MaxLength(2000)]
    public string? Description { get; set; }

    public bool IsResolved { get; set; }

    public Guid MeterPointId { get; set; }

    public MeterPoint MeterPoint { get; set; } = null!;

    public Guid ReadingId { get; set; }

    public Reading Reading { get; set; } = null!;
}
