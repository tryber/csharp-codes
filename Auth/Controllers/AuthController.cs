using Microsoft.AspNetCore.Mvc;
using Auth.ViewModels;
using Auth.Models;
using Auth.Services;
using Auth.Repository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Auth.Controllers;

public class AuthController : Controller
{
    [HttpPost]
    [Route("authenticate")]
    [AllowAnonymous]
    public ActionResult<UserViewModel> Authenticate([FromBody] User user)
    {
        UserViewModel userViewModel = new UserViewModel();
        
        try
        {
            userViewModel.User = new UserRepository().Get(user);
            //Console.WriteLine(userViewModel.User.Name + "bbbbbbbbb");
            if (userViewModel.User == null)
            {                
                return NotFound("User not found!");
            }
            userViewModel.Token = new TokenGenerator().Generate();
            userViewModel.User.Password = string.Empty;
        }
        catch (Exception ex)
        {
            Console.WriteLine("erro " + ex.Message);
            return BadRequest(ex.Message);
        }
        return userViewModel;
    }
}