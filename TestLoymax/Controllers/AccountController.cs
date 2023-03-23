using Microsoft.AspNetCore.Mvc;
using TestLoymax.Core.Interfaces;
using TestLoymax.Dtos.Account;

namespace TestLoymax.Controllers;

/// <summary>
///     Контроллер для работы с аккаунтами.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AccountController : Controller
{
    /// <summary>
    ///     Сервис для работы с аккаунтами.
    /// </summary>
    private readonly IAccountService _accountService;

    /// <summary>
    ///     Маппер аккаунтов.
    /// </summary>
    private readonly IAccountMapper _accountMapper;

    /// <summary>
    ///     Конструктор.
    /// </summary>
    public AccountController(IAccountService accountService,
        IAccountMapper accountMapper)
    {
        _accountService = accountService;
        _accountMapper = accountMapper;
    }

    /// <summary>
    ///     Получение информации по счету аккаунта.
    /// </summary>
    /// <param name="accountId"> Идентификатор аккаунта. </param>
    /// <returns> Количество денег. </returns>
    [HttpGet("{accountId}/money")]
    public async Task<AccountDto> GetAccountMoneyAsync(Guid accountId)
    {
        var account = await _accountService.GetMoneyAsync(accountId);
        return _accountMapper.ToDto(account);
    }

    /// <summary>
    ///     Зачисление денег.
    /// </summary>
    /// <param name="accountId"> Идентификатор аккаунта. </param>
    /// <param name="accountDto"> Информация по аккаунту. </param>
    [HttpPatch("{accountId}/money/add")]
    public async Task AddMoneyAsync(Guid accountId, AccountDto accountDto)
    {
        var account = _accountMapper.ToDbo(accountDto);
        await _accountService.AddMoneyAsync(account);
    }

    /// <summary>
    ///     Списание денег.
    /// </summary>
    /// <param name="accountId"> Идентификатор аккаунта. </param>
    /// <param name="accountDto"> Информация по аккаунту. </param>
    [HttpPatch("{accountId}/money/take")]
    public async Task TakeMoneyAsync(Guid accountId, AccountDto accountDto)
    {
        var account = _accountMapper.ToDbo(accountDto);
        await _accountService.TakeMoneyAsync(account);
    }
}