using Vaultex.Application.DTOs.Accounts;
using Vaultex.Domain.Entities.Accounts;
using Vaultex.Domain.Interfaces;

namespace Vaultex.Application.UseCases.Accounts;

public class CreateAccountUseCase(IAccountRepository repository)
{
    public async Task<AccountResponse> ExecuteAsync(CancellationToken ct = default)
    {
        var account = Account.Create();

        await repository.AddAsync(account, ct);

        return new AccountResponse(
            account.Id,
            account.Status.ToString().ToLower(),
            account.InsertedAt
        );
    } 
}