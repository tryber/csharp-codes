using Microsoft.AspNetCore.Mvc;
using Auth.API.Repository;
using Auth.API.DTO;
using Auth.API.Services;
using Auth.API.Models;
using System.Net;

namespace Auth.API.Controllers.Controllers;

[ApiController]
[Route("login")]

public class LoginController : Controller
{
     private readonly IUserRepository _repository;
     private readonly INotificationService _notificationService;
     private readonly ILogger<LoginController> _logger;
     public LoginController(IUserRepository repository, INotificationService notificationService, ILogger<LoginController> logger)
     {
        _repository = repository;
        _notificationService = notificationService;
        _logger = logger;
     }

     [HttpPost]
        public IActionResult Login([FromBody] LoginDTO user)
        {
            try
            {
                var userLogged = _repository.Login(user);
                var UserAgent = HttpContext.Request.Headers.UserAgent;
                var dateTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                var messageText = "<h4>Novo login realizado no ShopTrybe </h4>";
                messageText += "<p> Origem: " + UserAgent;
                messageText += "<br /> Data: " + dateTime+"</p>";
                messageText += "<p> Caso não reconheça este login, revise seus dados de autenticação.</p>";

                Message message = new Message {
                    Title = "Shop Trybe - Novo login",
                    Text = messageText,
                    MailTo = user.Email
                };
                _notificationService.Send(message);
                _logger.LogInformation("New login request");
                return Ok(new { token = AuthService.GenerateToken(userLogged)});
            }
            catch (Exception ex) {
                _logger.LogError(message: ex.Message.ToString(), ex);
                return BadRequest( new { message = ex.Message.ToString() });
            }
            
        }
}

