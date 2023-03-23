using TestLoymax.Core.Data;

namespace TestLoymax.Core.Interfaces;

/// <summary>
///     Сервис для проверки данных аккаунта.
/// </summary>
public interface IAccountValidationService
{
    /// <summary>
    ///     Проверка наличия аккаунта.
    /// </summary>
    /// <param name="account"> Аккаунт. </param>
    /// <param name="id"> Идентификатор. </param>
    void ThrowIfAccountNotFound(Account account, Guid id);

    /// <summary>
    ///     Проверка возможности списания денег со счета.
    /// </summary>
    /// <param name="account"> Аккаунт. </param>
    /// <param name="money"> Списываемые деньги. </param>
    void ThrowIfNotEnoughMoney(Account account, double money);
}