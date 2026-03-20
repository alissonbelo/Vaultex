using Microsoft.EntityFrameworkCore;
using Vaultex.Domain.Entities.Accounts;

namespace Vaultex.Infrastructure.Persistence;

public class VaultexDbContext(DbContextOptions<VaultexDbContext> options) : DbContext(options)
{
    public DbSet<Account> Accounts => Set<Account>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(e =>
        {
            e.HasKey(a => a.Id);

            e.Property(a => a.Id)
                .ValueGeneratedNever();

            e.Property(a => a.Status)
                .HasConversion<string>()
                .HasMaxLength(20)
                .IsRequired();

            e.Property(a => a.InsertedAt)
                .IsRequired();

            e.ToTable("accounts");
        });
    }
}