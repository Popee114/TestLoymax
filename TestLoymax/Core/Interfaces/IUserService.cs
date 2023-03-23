using TestLoymax.Core.Data;

namespace TestLoymax.Core.Interfaces;

/// <summary>
///     Сервис для работы пользователями.
/// </summary>
public interface IUserService
{
    /// <summary>
    ///     Создание пользователя.
    /// </summary>
    /// <param name="newUser"> Модель нового пользователя. </param>
    /// <returns> Созданный пользователь. </returns>
    public Task<User> CreateUserAsync(User newUser);
}