using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolEnergyOptimizer.Data.Models.Entities;

namespace SchoolEnergyOptimizer.Data.Configurations;

public class BuildingConfiguration : IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.Address)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(b => b.TotalAreaSqM)
            .HasPrecision(18, 2);

        builder.Property(b => b.Description)
            .HasMaxLength(2000);
    }
}
