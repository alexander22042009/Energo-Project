namespace SchoolEnergyOptimizer.Data.Models.Entities;

public static class RoleNames
{
    public const string Administrator = "Administrator";

    public const string Director = "Director";

    public const string Analyst = "Analyst";

    public const string Operator = "Operator";

    public static readonly IReadOnlyList<string> All =
    [
        Administrator,
        Director,
        Analyst,
        Operator
    ];
}
