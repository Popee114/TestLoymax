namespace TestLoymax.Dtos.User;

/// <summary>
///     Модель для чтения данных о пользователе.
/// </summary>
public class UserReadDto : UserCreateDto
{
    /// <summary>
    ///     Идентификатор пользователя.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     Идентификатор аккаунта.
    /// </summary>
    public Guid AccountId { get; set; }
}