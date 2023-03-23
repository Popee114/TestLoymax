using TestLoymax.Core.Data;
using TestLoymax.Core.Interfaces;
using TestLoymax.Dtos.Account;

namespace TestLoymax.Core.Mappers;

/// <summary>
///     Маппер аккаунтов.
/// </summary>
public class AccountMapper : IAccountMapper
{
    /// <inheritdoc />
    public AccountDto ToDto(Account account)
    {
        return new AccountDto
        {
            AccountId = account.Id,
            Money = account.Money
        };
    }

    /// <inheritdoc />
    public Account ToDbo(AccountDto accountDto)
    {
        return new Account
        {
            Id = accountDto.AccountId,
            Money = accountDto.Money
        };
    }
}