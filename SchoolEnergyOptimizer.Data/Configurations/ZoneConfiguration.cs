using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolEnergyOptimizer.Data.Models.Entities;

namespace SchoolEnergyOptimizer.Data.Configurations;

public class ZoneConfiguration : IEntityTypeConfiguration<Zone>
{
    public void Configure(EntityTypeBuilder<Zone> builder)
    {
        builder.HasKey(z => z.Id);

        builder.Property(z => z.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(z => z.AreaSqM)
            .HasPrecision(18, 2);

        builder.Property(z => z.ZoneType)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.HasOne(z => z.Building)
            .WithMany(b => b.Zones)
            .HasForeignKey(z => z.BuildingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
