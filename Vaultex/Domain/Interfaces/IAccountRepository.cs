using Vaultex.Domain.Entities.Accounts;

namespace Vaultex.Domain.Interfaces;

public interface IAccountRepository
{
    Task<Account?> GetByIdAsync(Guid id, CancellationToken ct = default);
    Task<List<Account>> ListAsync(CancellationToken ct = default);
    Task AddAsync(Account account, CancellationToken ct = default);
}