using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolEnergyOptimizer.Data.Models.Entities;

namespace SchoolEnergyOptimizer.Data.Configurations;

public class MeterPointConfiguration : IEntityTypeConfiguration<MeterPoint>
{
    public void Configure(EntityTypeBuilder<MeterPoint> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.SerialNumber)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(m => m.EnergyType)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.HasIndex(m => m.SerialNumber)
            .IsUnique();

        builder.HasOne(m => m.Zone)
            .WithMany(z => z.MeterPoints)
            .HasForeignKey(m => m.ZoneId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
