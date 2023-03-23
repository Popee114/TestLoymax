using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using TestLoymax.Configs;
using TestLoymax.Core.Data;

namespace TestLoymax.Core.Contexts;

/// <summary>
///     Контекст БД.
/// </summary>
public class LoymaxContext : DbContext
{
    /// <summary>
    ///     Строки подключения.
    /// </summary>
    // private readonly ConnectionStrings _connectionStrings;
    
    /// <summary>
    ///     Конструктор контекста c DI.
    /// </summary>
    // public LoymaxContext(IOptions<ConnectionStrings> options)
    // {
    //     _connectionStrings = options.Value;
    // }
    
    /// <summary>
    ///     Конструктор контекста c настройками.
    /// </summary>
    public LoymaxContext(DbContextOptions<LoymaxContext> options)
        :base(options)
    {
        
    }

    /// <summary>
    ///     Клиенты.
    /// </summary>
    public DbSet<User> Users => Set<User>();

    /// <summary>
    ///     Аккаунт.
    /// </summary>
    public DbSet<Account> Accounts => Set<Account>();

    /// <inheritdoc />
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    //     optionsBuilder.UseNpgsql(_connectionStrings.LoymaxContext);

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<User>()
            .HasOne(x => x.Account)
            .WithOne(x => x.Owner)
            .HasForeignKey<Account>(x => x.OwnerId);
        
        var keysProperties = modelBuilder.Model
            .GetEntityTypes()
            .Select(x => x.FindPrimaryKey())
            .SelectMany(x => x!.Properties);
        
        foreach (var property in keysProperties)
        {
            property.ValueGenerated = ValueGenerated.OnAdd;
        }
    }
}