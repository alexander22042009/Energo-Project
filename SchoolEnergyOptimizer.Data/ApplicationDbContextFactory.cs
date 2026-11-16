using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SchoolEnergyOptimizer.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var connectionString = ResolveConnectionString();
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new ApplicationDbContext(optionsBuilder.Options);
    }

    private static string ResolveConnectionString()
    {
        var fromEnvironment = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");
        if (!string.IsNullOrWhiteSpace(fromEnvironment))
        {
            return fromEnvironment;
        }

        var webProjectPath = FindWebProjectPath();
        var secretsId = ReadUserSecretsId(webProjectPath);
        if (!string.IsNullOrWhiteSpace(secretsId))
        {
            var secretsPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Microsoft",
                "UserSecrets",
                secretsId,
                "secrets.json");

            if (File.Exists(secretsPath))
            {
                var secret = ReadConnectionString(secretsPath);
                if (!string.IsNullOrWhiteSpace(secret))
                {
                    return secret;
                }
            }
        }

        throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");
    }

    private static string? ReadConnectionString(string secretsPath)
    {
        using var document = JsonDocument.Parse(File.ReadAllText(secretsPath));
        if (document.RootElement.TryGetProperty("ConnectionStrings:DefaultConnection", out var flat))
        {
            return flat.GetString();
        }

        if (document.RootElement.TryGetProperty("ConnectionStrings", out var connectionStrings)
            && connectionStrings.ValueKind == JsonValueKind.Object
            && connectionStrings.TryGetProperty("DefaultConnection", out var nested))
        {
            return nested.GetString();
        }

        return null;
    }

    private static string FindWebProjectPath()
    {
        var current = new DirectoryInfo(Directory.GetCurrentDirectory());
        while (current is not null)
        {
            var candidate = Path.Combine(current.FullName, "SchoolEnergyOptimizer.Web");
            if (File.Exists(Path.Combine(candidate, "SchoolEnergyOptimizer.Web.csproj")))
            {
                return candidate;
            }

            current = current.Parent;
        }

        throw new InvalidOperationException("SchoolEnergyOptimizer.Web project folder was not found.");
    }

    private static string ReadUserSecretsId(string webProjectPath)
    {
        var projectFile = Path.Combine(webProjectPath, "SchoolEnergyOptimizer.Web.csproj");
        var content = File.ReadAllText(projectFile);
        const string startTag = "<UserSecretsId>";
        const string endTag = "</UserSecretsId>";
        var start = content.IndexOf(startTag, StringComparison.Ordinal);
        if (start < 0)
        {
            return string.Empty;
        }

        start += startTag.Length;
        var end = content.IndexOf(endTag, start, StringComparison.Ordinal);
        if (end < 0)
        {
            return string.Empty;
        }

        return content[start..end].Trim();
    }
}
