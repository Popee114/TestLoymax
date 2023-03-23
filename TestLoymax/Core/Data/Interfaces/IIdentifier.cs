namespace TestLoymax.Core.Data.Interfaces;

/// <summary>
///     Интерфейс идентификатора.
/// </summary>
public interface IIdentifier
{
    /// <summary>
    ///     Идентификатор.
    /// </summary>
    public Guid Id { get; set; }
}