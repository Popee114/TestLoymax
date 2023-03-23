using Microsoft.EntityFrameworkCore;
using TestLoymax.Core.Contexts;
using TestLoymax.Core.Data;
using TestLoymax.Core.Interfaces;

namespace TestLoymax.Core.Services;

/// <summary>
///     Сервис для работы с аккаунтом.
/// </summary>
public class AccountService : IAccountService
{
    /// <summary>
    ///     Контекст БД.
    /// </summary>
    private readonly LoymaxContext _loymaxContext;
    
    /// <summary>
    ///     Сервис для проверки данных аккаунта.
    /// </summary>
    private readonly IAccountValidationService _accountValidationService;

    /// <summary>
    ///     Конструктор сервиса.
    /// </summary>
    public AccountService(IAccountValidationService accountValidationService,
        LoymaxContext loymaxContext)
    {
        _accountValidationService = accountValidationService;
        _loymaxContext = loymaxContext;
    }

    /// <inheritdoc />
    public async Task<Account> GetMoneyAsync(Guid accountId)
    {
        return await ReadAccountAsync(accountId);
    }

    /// <inheritdoc />
    public async Task AddMoneyAsync(Account account)
    {
        var currentAccount = await ReadAccountWithoutTrackingAsync(account);

        currentAccount.Money += account.Money;

        await _loymaxContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task TakeMoneyAsync(Account account)
    {
        var currentAccount = await ReadAccountWithoutTrackingAsync(account);

        _accountValidationService.ThrowIfNotEnoughMoney(account, account.Money);
        
        currentAccount.Money -= account.Money;

        await _loymaxContext.SaveChangesAsync();
    }

    /// <summary>
    ///     Чтение данных по аккаунту.
    /// </summary>
    /// <param name="accountId"> Идентификатор аккаунта. </param>
    /// <returns> Аккаунт. </returns>
    private async Task<Account> ReadAccountAsync(Guid accountId)
    {
        var account = await _loymaxContext.Accounts
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == accountId);
        
        _accountValidationService.ThrowIfAccountNotFound(account, accountId);

        return account;
    }

    /// <summary>
    ///     Чтение данных по аккаунту.
    /// </summary>
    /// <param name="account"> Aккаунт. </param>
    /// <returns> Аккаунт. </returns>
    private async Task<Account> ReadAccountWithoutTrackingAsync(Account account)
    {
        var currentAccount = await _loymaxContext.Accounts
            .FirstOrDefaultAsync(x => x.Id == account.Id);
        
        _accountValidationService.ThrowIfAccountNotFound(currentAccount, account.Id);

        return currentAccount;
    }
}