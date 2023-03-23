using TestLoymax.Core.Interfaces;
using TestLoymax.Core.Mappers;
using TestLoymax.Core.Services;

namespace TestLoymax.BuildExtensions;

/// <summary>
///     Расширение для регистрации сервисов с ЖЦ <see cref="ServiceLifetime.Transient"/>.
/// </summary>
public static class RegistrationTransientsExtension
{
    /// <summary>
    ///     Регистрация сервисов с ЖЦ <see cref="ServiceLifetime.Transient"/>.
    /// </summary>
    /// <param name="serviceCollection"> Коллекция сервисов. </param>
    public static void RegistrationTransients(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddTransient<IAccountMapper, AccountMapper>()
            .AddTransient<IUserMapper, UserMapper>()
            .AddTransient<IAccountValidationService, AccountValidationService>();
    }
}