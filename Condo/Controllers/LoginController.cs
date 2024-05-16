using Condo.DTOs;
using Condo.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condo.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    protected readonly ILoginUser _loginUser;

    public LoginController(ILoginUser loginUser)
    {
        _loginUser = loginUser;
    }

    [HttpPost]
    public IActionResult Login([FromBody] LoginRequestDTO loginRequestDTO)
    {
        return Ok(_loginUser.Execute(loginRequestDTO));
    }

}