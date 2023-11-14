using Microsoft.AspNetCore.Mvc;
using Authorize.Models;
using Authorize.Services;
using Authorize.Repository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Authorize.Controllers;

public class AuthorizationController : Controller
{
    [HttpGet]
    [Route("MessageForStudentsSa")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "SouthAmerica")]
    public ActionResult<string> MessageForStudentsSA()
    {
        return "Parabéns pela sua jornada até aqui como pessoa desenvolvedora na América do Sul!";
    }

    [HttpGet]
    [Route("MessageForStudents")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize]
    public ActionResult<string> MessageForStudents()
    {
        return "Parabéns pela sua jornada até aqui como pessoa desenvolvedora!";
    }


    [HttpGet]
    [Route("MessageForAll")]
    [AllowAnonymous]
    public ActionResult<string> MessageForAll()
    {
        return "Mensagem para todas as pessoas";
    }

    [HttpPost]
    [Route("GetEmail")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "Client")]
    public IActionResult PostAdd([FromBody] User requestBody)
    {

        var token = HttpContext.User.Identity as ClaimsIdentity;
        var email = token?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

        // operações a serem realizadas no banco de dados
        return Ok("Seu e-mail é: " + email);

    }


}