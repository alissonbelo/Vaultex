using Vaultex.Application.UseCases.Accounts;

namespace Vaultex.Api.Endpoints;

public static class AccountEndpoints
{
    public static void MapAccountEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/accounts").WithTags("Accounts");

        group.MapGet("/", async (ListAccountsUseCase useCase, CancellationToken ct) =>
        {
            var accounts = await useCase.ExecuteAsync(ct);
            return Results.Ok(new { data = accounts });
        });

        group.MapGet("/{id:guid}", async (Guid id, GetAccountUseCase useCase, CancellationToken ct) =>
        {
            try
            {
                var account = await useCase.ExecuteAsync(id, ct);
                return Results.Ok(new { data = account });
            }
            catch (KeyNotFoundException ex)
            {
                return Results.NotFound(new { error = ex.Message });
            }
        });

        group.MapPost("/", async (CreateAccountUseCase useCase, CancellationToken ct) =>
        {
            var account = await useCase.ExecuteAsync(ct);
            return Results.Created($"/api/accounts/{account.Id}", new { data = account });
        });
    }
}