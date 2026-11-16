using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolEnergyOptimizer.Data.Models.Entities;

namespace SchoolEnergyOptimizer.Data.Configurations;

public class ReadingConfiguration : IEntityTypeConfiguration<Reading>
{
    public void Configure(EntityTypeBuilder<Reading> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Timestamp)
            .IsRequired();

        builder.Property(r => r.Value)
            .HasPrecision(18, 4);

        builder.Property(r => r.CalculatedCost)
            .HasPrecision(18, 2);

        builder.Property(r => r.Source)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.HasOne(r => r.MeterPoint)
            .WithMany(m => m.Readings)
            .HasForeignKey(r => r.MeterPointId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Tariff)
            .WithMany(t => t.Readings)
            .HasForeignKey(r => r.TariffId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(r => r.RecordedByUser)
            .WithMany(u => u.RecordedReadings)
            .HasForeignKey(r => r.RecordedByUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(r => new { r.MeterPointId, r.Timestamp });
    }
}
