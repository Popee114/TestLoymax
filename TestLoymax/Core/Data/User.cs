using TestLoymax.Core.Data.Interfaces;

namespace TestLoymax.Core.Data;

/// <summary>
///     Пользователь.
/// </summary>
public class User : IIdentifier
{
    /// <inheritdoc />
    public Guid Id { get; set; }

    /// <summary>
    ///     Фамилия.
    /// </summary>
    public string Surname { get; set; }

    /// <summary>
    ///     Имя.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///     Отчество.
    /// </summary>
    public string Patronymic { get; set; }

    /// <summary>
    ///     День рождения.
    /// </summary>
    public DateTime Birthday { get; set; }

    /// <summary>
    ///     Аккаунт.
    /// </summary>
    public Account Account { get; set; }

    /// <summary>
    ///     Идентификатор аккаунта.
    /// </summary>
    public Guid AccountId { get; set; }
}