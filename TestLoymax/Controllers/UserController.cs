using Microsoft.AspNetCore.Mvc;
using TestLoymax.Core.Interfaces;
using TestLoymax.Dtos.User;

namespace TestLoymax.Controllers;

/// <summary>
///     Контроллер для работы с пользователями.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    /// <summary>
    ///     Сервис для работы с пользователями.
    /// </summary>
    private readonly IUserService _userService;

    /// <summary>
    ///     Маппер пользователей.
    /// </summary>
    private readonly IUserMapper _userMapper;
    
    /// <summary>
    ///     Конструктор.
    /// </summary>
    public UserController(IUserService userService,
        IUserMapper userMapper)
    {
        _userService = userService;
        _userMapper = userMapper;
    }

    /// <summary>
    ///     Создание пользователя.
    /// </summary>
    /// <param name="userDto"> Транспортная модель пользователя. </param>
    /// <returns> Данные о созданном пользователе. </returns>
    [HttpPost]
    public async Task<UserReadDto> CreateUserAsync(UserCreateDto userDto)
    {
        var user = _userMapper.CreateDtoToDbo(userDto);
        var createdUser = await _userService.CreateUserAsync(user);
        return _userMapper.ToReadDto(createdUser);
    }
}