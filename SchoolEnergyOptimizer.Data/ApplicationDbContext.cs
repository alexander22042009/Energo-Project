using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolEnergyOptimizer.Data.Models.Entities;

namespace SchoolEnergyOptimizer.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Building> Buildings => Set<Building>();

    public DbSet<Zone> Zones => Set<Zone>();

    public DbSet<MeterPoint> MeterPoints => Set<MeterPoint>();

    public DbSet<Reading> Readings => Set<Reading>();

    public DbSet<Tariff> Tariffs => Set<Tariff>();

    public DbSet<AnomalyAlert> AnomalyAlerts => Set<AnomalyAlert>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
