using Vaultex.Application.DTOs.Accounts;
using Vaultex.Domain.Interfaces;

namespace Vaultex.Application.UseCases.Accounts;

public class GetAccountUseCase(IAccountRepository repository)
{
    public async Task<AccountResponse> ExecuteAsync(Guid id, CancellationToken ct = default)
    {
        var account = await repository.GetByIdAsync(id, ct);

        if (account is null)
            throw new KeyNotFoundException("Conta não encontrada.");

        return new AccountResponse(
            account.Id,
            account.Status.ToString().ToLower(),
            account.InsertedAt
        );
    }
}