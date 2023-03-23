namespace TestLoymax.Dtos.User;

/// <summary>
///     Модель для создания пользователя.
/// </summary>
public class UserCreateDto
{
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
}