using Condo.DTOs;
using Condo.Models;
using Condo.UseCases.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Condo.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    protected readonly ICreateUser _createUser;
    protected readonly IVerifyUser _verifyUser;
    protected readonly IChangePasswordUser _changePasswordUser;

    public UserController(ICreateUser createUser, IVerifyUser verifyUser, IChangePasswordUser changePasswordUser)
    {
        _createUser = createUser;
        _verifyUser = verifyUser;
        _changePasswordUser = changePasswordUser;
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "Administrator")]
    public IActionResult Add([FromBody] UserCreateDTO userCreateDTO)
    {
        return Created("", _createUser.Execute(userCreateDTO));
    }

    [HttpPost("verify")]
    public IActionResult Verify([FromBody] UserSetPasswordDTO userSetPasswordDTO)
    {
        _verifyUser.Execute(userSetPasswordDTO);
        return Ok( new { message = "User verified" });
    }

    [HttpPatch("changepass")]
    public IActionResult ChangePassword([FromBody] UserChangePasswordDTO userChangePasswordDTO)
    {
        _changePasswordUser.Execute(userChangePasswordDTO);
        return Ok( new { message = "Password changed" });
    }
    
}
