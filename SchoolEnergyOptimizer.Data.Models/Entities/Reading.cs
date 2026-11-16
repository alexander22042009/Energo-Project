using System.ComponentModel.DataAnnotations.Schema;
using SchoolEnergyOptimizer.Data.Models.Enums;

namespace SchoolEnergyOptimizer.Data.Models.Entities;

public class Reading
{
    public Guid Id { get; set; }

    public DateTime Timestamp { get; set; }

    [Column(TypeName = "decimal(18,4)")]
    public decimal Value { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal CalculatedCost { get; set; }

    public ReadingSource Source { get; set; }

    public Guid MeterPointId { get; set; }

    public MeterPoint MeterPoint { get; set; } = null!;

    public Guid TariffId { get; set; }

    public Tariff Tariff { get; set; } = null!;

    public Guid RecordedByUserId { get; set; }

    public ApplicationUser RecordedByUser { get; set; } = null!;

    public ICollection<AnomalyAlert> AnomalyAlerts { get; set; } = new List<AnomalyAlert>();
}
