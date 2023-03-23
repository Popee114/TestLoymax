using TestLoymax.Core.Data;
using TestLoymax.Core.Interfaces;

namespace TestLoymax.Core.Services;

/// <summary>
///     Сервис проверки данных аккаунта.
/// </summary>
public class AccountValidationService : IAccountValidationService
{
    /// <inheritdoc />
    public void ThrowIfAccountNotFound(Account account, Guid id)
    {
        if (account is null)
            throw new Exception($"Account with id {id.ToString()} not found.");
    }

    /// <inheritdoc />
    public void ThrowIfNotEnoughMoney(Account account, double money)
    {
        if (account.Money - money < 0)
            throw new Exception($"Account with id {account.Id.ToString()} has a little money.");
    }
}