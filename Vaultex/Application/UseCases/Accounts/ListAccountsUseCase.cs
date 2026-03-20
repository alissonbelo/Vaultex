using Vaultex.Application.DTOs.Accounts;
using Vaultex.Domain.Interfaces;

namespace Vaultex.Application.UseCases.Accounts;

public class ListAccountsUseCase(IAccountRepository repository)
{
    public async Task<List<AccountResponse>> ExecuteAsync(CancellationToken ct = default)
    {
        var accounts = await repository.ListAsync(ct);

        return accounts
            .Select(a => new AccountResponse(
                a.Id,
                a.Status.ToString().ToLower(),
                a.InsertedAt
            ))
            .ToList();
    }
}