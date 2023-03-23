using Microsoft.AspNetCore.Mvc;

namespace TestLoymax.Dtos.Account;

/// <summary>
///     Транспортная модель аккаунта.
/// </summary>
public class AccountDto
{
    /// <summary>
    ///     Идентификатор аккаунта.
    /// </summary>
    public Guid AccountId { get; set; }

    /// <summary>
    ///     Деньги.
    /// </summary>
    public double Money { get; set; }
}