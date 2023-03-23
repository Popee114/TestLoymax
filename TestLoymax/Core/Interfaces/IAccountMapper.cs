using TestLoymax.Core.Data;
using TestLoymax.Dtos.Account;

namespace TestLoymax.Core.Interfaces;

/// <summary>
///     Интерфейс маппера аккаунтов.
/// </summary>
public interface IAccountMapper
{
    /// <summary>
    ///     Маппинг акканута в ДТО.
    /// </summary>
    /// <param name="account"> Аккаунт. </param>
    /// <returns> ДТО. </returns>
    public AccountDto ToDto(Account account);
    
    /// <summary>
    ///     Маппинг ДТО в аккаунт.
    /// </summary>
    /// <param name="accountDto"> ДТО. </param>
    /// <returns> Аккаунт. </returns>
    public Account ToDbo(AccountDto accountDto);
}