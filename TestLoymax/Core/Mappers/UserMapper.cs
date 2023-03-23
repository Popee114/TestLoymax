using TestLoymax.Core.Data;
using TestLoymax.Core.Interfaces;
using TestLoymax.Dtos.User;

namespace TestLoymax.Core.Mappers;

/// <summary>
///     Маппер пользователей.
/// </summary>
public class UserMapper : IUserMapper
{
    /// <inheritdoc />
    public UserReadDto ToReadDto(User user)
    {
        return new UserReadDto
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            Patronymic = user.Patronymic,
            Birthday = user.Birthday,
            AccountId = user.AccountId
        };
    }
    
    /// <inheritdoc />
    public User CreateDtoToDbo(UserCreateDto userDto)
    {
        return new User
        {
            Name = userDto.Name,
            Surname = userDto.Surname,
            Patronymic = userDto.Patronymic,
            Birthday = userDto.Birthday,
        };
    }
}