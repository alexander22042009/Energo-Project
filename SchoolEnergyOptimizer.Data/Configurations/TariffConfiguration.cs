using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolEnergyOptimizer.Data.Models.Entities;

namespace SchoolEnergyOptimizer.Data.Configurations;

public class TariffConfiguration : IEntityTypeConfiguration<Tariff>
{
    public void Configure(EntityTypeBuilder<Tariff> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(t => t.EnergyType)
            .HasConversion<string>()
            .HasMaxLength(50);

        builder.Property(t => t.PricePerUnit)
            .HasPrecision(18, 2);

        builder.Property(t => t.ValidFrom)
            .IsRequired();
    }
}
