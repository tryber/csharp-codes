using Microsoft.AspNetCore.Mvc;
using Authorize.Models;
using Authorize.Services;
using Authorize.Repository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Authorize.Controllers;

public class AuthController : Controller
{
    [HttpPost]
    [Route("authenticate")]
    [AllowAnonymous]
    public IActionResult Authenticate([FromBody] User user)
    {
        
        try
        {
           User foundedUser = new UserRepository().Get(user);
            
            if (foundedUser == null)
            {                
                return NotFound("User not found!");
            }
            var token = new TokenGenerator().Generate(foundedUser);
            return Ok(new { token });
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}