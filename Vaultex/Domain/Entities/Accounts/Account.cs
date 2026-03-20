namespace Vaultex.Domain.Entities;

public class Account
{
    public Guid Id { get; private set; }
    public AccountStatus Status { get; private set; }
    public DateTime InsertedAt { get; private set; }

    private Account() { }

    public static Account Create()
    {
        return new Account
        {
            Id = Guid.NewGuid(),
            Status = AccountStatus.Active,
            InsertedAt = DateTime.UtcNow
        };
    }

    public void Block()
    {
        if (Status == AccountStatus.Closed)
            throw new InvalidOperationException("Conta encerrada não pode ser bloqueada.");

        Status = AccountStatus.Blocked;
    }

    public void Close()
    {
        Status = AccountStatus.Closed;
    }
    
}