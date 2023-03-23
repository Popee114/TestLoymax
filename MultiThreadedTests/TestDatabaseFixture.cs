using System.Runtime.Intrinsics.X86;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestLoymax.Core.Contexts;
using TestLoymax.Core.Interfaces;
using TestLoymax.Core.Mappers;
using TestLoymax.Core.Services;

namespace MultiThreadedTests;

public class TestDatabaseFixture : IDisposable
{
    private readonly IConfiguration _configuration;

    public readonly IServiceProvider ServiceProvider;
    
    public TestDatabaseFixture()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, false);

        _configuration = builder.Build();
        
        var services = new ServiceCollection();
        
        services.AddDbContext<LoymaxContext>(options =>
                options.UseNpgsql(_configuration.GetConnectionString(nameof(LoymaxContext))));

        services
            .AddScoped<IAccountService, AccountService>()
            .AddScoped<IUserService, UserService>()
            .AddTransient<IAccountMapper, AccountMapper>()
            .AddTransient<IUserMapper, UserMapper>()
            .AddTransient<IAccountValidationService, AccountValidationService>();

        ServiceProvider = services.BuildServiceProvider();

        MigrateDb();
    }

    private void MigrateDb()
    {
        using var scope = ServiceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<LoymaxContext>();
        context.Database.Migrate();
    }

    public void Dispose()
    {
        using var scope = ServiceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<LoymaxContext>();
        context.Database.EnsureDeleted();
    }
}