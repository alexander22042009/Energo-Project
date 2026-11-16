using SchoolEnergyOptimizer.Data.Models.Entities;

namespace SchoolEnergyOptimizer.Data.Seeding;

public static class IdentityRoleSeed
{
    public static readonly ApplicationRole[] Roles =
    [
        Create("5c9f0a31-7b14-4e2a-8d55-01a1a1a1a1a1", RoleNames.Administrator),
        Create("5c9f0a31-7b14-4e2a-8d55-02b2b2b2b2b2", RoleNames.Director),
        Create("5c9f0a31-7b14-4e2a-8d55-03c3c3c3c3c3", RoleNames.Analyst),
        Create("5c9f0a31-7b14-4e2a-8d55-04d4d4d4d4d4", RoleNames.Operator)
    ];

    private static ApplicationRole Create(string id, string name)
    {
        return new ApplicationRole
        {
            Id = Guid.Parse(id),
            Name = name,
            NormalizedName = name.ToUpperInvariant(),
            ConcurrencyStamp = id
        };
    }
}
