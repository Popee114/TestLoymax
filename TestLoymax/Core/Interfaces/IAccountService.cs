using TestLoymax.Core.Data;

namespace TestLoymax.Core.Interfaces;

/// <summary>
///     Интерфейс сервиса для
/// </summary>
public interface IAccountService
{
    /// <summary>
    ///     Получение информации по счету.
    /// </summary>
    /// <param name="accountId"> Идентификатор аккаунта. </param>
    /// <returns> Аккаунт. </returns>
    public Task<Account> GetMoneyAsync(Guid accountId);

    /// <summary>
    ///     Пополнение счета.
    /// </summary>
    /// <param name="account"> Aккаунт. </param>
    public Task AddMoneyAsync(Account account);

    /// <summary>
    ///     Списание со счета.
    /// </summary>
    /// <param name="account"> Aккаунт. </param>
    public Task TakeMoneyAsync(Account account);
}