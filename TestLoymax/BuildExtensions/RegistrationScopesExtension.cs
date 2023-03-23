using TestLoymax.Core.Interfaces;
using TestLoymax.Core.Services;

namespace TestLoymax.BuildExtensions;

/// <summary>
///     Расширение для регистрации сервисов с ЖЦ <see cref="ServiceLifetime.Scoped"/>.
/// </summary>
public static class RegistrationScopesExtension
{
    /// <summary>
    ///     Регистрация сервисов с ЖЦ <see cref="ServiceLifetime.Scoped"/>.
    /// </summary>
    /// <param name="serviceCollection"> Коллекция сервисов. </param>
    public static void RegistrationScopes(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IUserService, UserService>();
    }
}