using TestLoymax.Core.Contexts;
using TestLoymax.Core.Data;
using TestLoymax.Core.Interfaces;

namespace TestLoymax.Core.Services;

/// <summary>
///     Сервис для работы с пользователями.
/// </summary>
public class UserService : IUserService
{
    /// <summary>
    ///     Контекст БД.
    /// </summary>
    private readonly LoymaxContext _loymaxContext;
    
    /// <summary>
    ///     Конструктор.
    /// </summary>
    public UserService(LoymaxContext loymaxContext)
    {
        _loymaxContext = loymaxContext;
    }
    
    /// <inheritdoc />
    public async Task<User> CreateUserAsync(User user)
    {
        user.Account = new Account
        {
            Money = 0
        };

        _loymaxContext.Users.Add(user);
        await _loymaxContext.SaveChangesAsync();

        user.AccountId = user.Account.Id;
        
        return user;
    }
}