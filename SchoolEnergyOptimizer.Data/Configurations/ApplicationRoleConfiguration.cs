using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolEnergyOptimizer.Data.Models.Entities;
using SchoolEnergyOptimizer.Data.Seeding;

namespace SchoolEnergyOptimizer.Data.Configurations;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.HasData(IdentityRoleSeed.Roles);
    }
}
