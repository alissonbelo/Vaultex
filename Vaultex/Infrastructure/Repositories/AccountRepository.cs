using Microsoft.EntityFrameworkCore;
using Vaultex.Domain.Entities.Accounts;
using Vaultex.Domain.Interfaces;
using Vaultex.Infrastructure.Persistence;

namespace Vaultex.Infrastructure.Repositories;

public class AccountRepository(VaultexDbContext db) : IAccountRepository
{
    public async Task<Account?> GetByIdAsync(Guid id, CancellationToken ct = default) =>
        await db.Accounts.FindAsync([id], ct);

    public async Task<List<Account>> ListAsync(CancellationToken ct = default) =>
        await db.Accounts.ToListAsync(ct);

    public async Task AddAsync(Account account, CancellationToken ct = default)
    {
        await db.Accounts.AddAsync(account, ct);
        await db.SaveChangesAsync(ct);
    }
}