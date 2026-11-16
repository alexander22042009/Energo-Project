using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolEnergyOptimizer.Data.Models.Entities;

namespace SchoolEnergyOptimizer.Data.Configurations;

public class AnomalyAlertConfiguration : IEntityTypeConfiguration<AnomalyAlert>
{
    public void Configure(EntityTypeBuilder<AnomalyAlert> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.DetectedOn)
            .IsRequired();

        builder.Property(a => a.MeasuredValue)
            .HasPrecision(18, 4);

        builder.Property(a => a.ExpectedBaselineValue)
            .HasPrecision(18, 4);

        builder.Property(a => a.DeviationPercentage)
            .HasPrecision(18, 4);

        builder.Property(a => a.Description)
            .HasMaxLength(2000);

        builder.HasOne(a => a.MeterPoint)
            .WithMany(m => m.AnomalyAlerts)
            .HasForeignKey(a => a.MeterPointId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Reading)
            .WithMany(r => r.AnomalyAlerts)
            .HasForeignKey(a => a.ReadingId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
