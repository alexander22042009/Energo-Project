using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolEnergyOptimizer.Data.Models.Enums;

namespace SchoolEnergyOptimizer.Data.Models.Entities;

public class Tariff
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    public EnergyType EnergyType { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal PricePerUnit { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public bool IsNightTariff { get; set; }

    public ICollection<Reading> Readings { get; set; } = new List<Reading>();
}
