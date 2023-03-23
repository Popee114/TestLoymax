using TestLoymax.Core.Data.Interfaces;

namespace TestLoymax.Core.Data;

/// <summary>
///     Акканут клиента.
/// </summary>
public class Account : IIdentifier
{
    /// <inheritdoc />
    public Guid Id { get; set; }

    /// <summary>
    ///     Деньги.
    /// </summary>
    public double Money { get; set; }

    /// <summary>
    ///     Владелец аккаунта.
    /// </summary>
    public User Owner { get; set; }

    /// <summary>
    ///     Идентификатор владельца.
    /// </summary>
    public Guid OwnerId { get; set; }
}