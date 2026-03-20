using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Vaultex.Infrastructure.Persistence;

public class VaultexDbContextFactory : IDesignTimeDbContextFactory<VaultexDbContext>
{
    public VaultexDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var options = new DbContextOptionsBuilder<VaultexDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"))
            .Options;

        return new VaultexDbContext(options);
    }
}