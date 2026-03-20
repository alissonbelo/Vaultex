namespace Vaultex.Application.DTOs.Accounts;

public record AccountResponse(
    Guid Id,
    string Status,
    DateTime InsertedAt
);