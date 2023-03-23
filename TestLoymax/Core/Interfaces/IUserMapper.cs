using TestLoymax.Core.Data;
using TestLoymax.Dtos.User;

namespace TestLoymax.Core.Interfaces;

/// <summary>
///     Интерфейс маппера пользователей.
/// </summary>
public interface IUserMapper
{
    /// <summary>
    ///     Маппинг пользователя в модель для чтения.
    /// </summary>
    /// <param name="user"> Пользователь. </param>
    /// <returns> ДТО для чтения. </returns>
    public UserReadDto ToReadDto(User user);

    /// <summary>
    ///     Маппинг модели пользователя для создания. 
    /// </summary>
    /// <param name="userDto"> ДТО пользователя. </param>
    /// <returns> Пользователь. </returns>
    public User CreateDtoToDbo(UserCreateDto userDto);
}