using Domain.Dtos;
using Infrastructure.Serivices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginDto login)
    {
        var result = await _accountService.Login(login);
        if (result == null)
        {
            return BadRequest(login);
        }

        return Ok(result);
    }
    
    [HttpPost("register")]
    [AllowAnonymous]
    public async  Task<IActionResult> Register(RegisterDto register)
    {
        var result = await _accountService.Register(register);
        if (result == null)
        {
            return BadRequest(register);
        }

        return Ok(result);
    }
    
}