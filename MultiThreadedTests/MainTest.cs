using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestLoymax.Core.Contexts;
using TestLoymax.Core.Data;

namespace MultiThreadedTests;

public class MainTest : IDisposable
{
    private TestDatabaseFixture _testDatabaseFixture;
    
    public MainTest()
    {
        _testDatabaseFixture = new TestDatabaseFixture();
    }
    
    [Fact]
    public async Task MultiThreadedAddingMoneyAsync()
    {
        // Arrange
        await using var scope = _testDatabaseFixture.ServiceProvider.CreateAsyncScope();
        var context = scope.ServiceProvider.GetService<LoymaxContext>();
        for (var i = 0; i < 50; i++)
        {
            var user = new User
            {
                Name = $"Name{i}",
                Surname = $"Surname{i}",
                Patronymic = $"Patronymic{i}",
                Account = new Account
                {
                    Money = 0
                }
            };

            context.Users.Add(user);
            user.AccountId = user.Account.Id;
        }

        await context.SaveChangesAsync();

        // Act

        // Assert
    }

    public void Dispose()
    {
        _testDatabaseFixture.Dispose();
    }
}