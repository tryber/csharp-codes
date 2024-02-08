using Microsoft.AspNetCore.Mvc;
using Auth.API.Repository;
using Auth.API.DTO;
using Auth.API.Services;
using Auth.API.Models;

namespace Auth.API.Controllers;

[ApiController]
[Route("user")]

public class UserController : Controller
{
     private readonly IUserRepository _repository;
    private readonly INotificationService _notificationService;
    private readonly ILogger<UserController> _logger;

     public UserController(IUserRepository repository, INotificationService notificationService, ILogger<UserController> logger)
     {
        _repository = repository;
        _notificationService = notificationService;
        _logger = logger;
     }

     [HttpPost]
        public IActionResult Create([FromBody] UserInsertDTO user)
        {
            try
            {
                var userCreated = _repository.Create(user);
                var messageText = "<h4>Cadastro realizado no ShopTrybe </h4>";
                messageText += "<p> Olá: " + user.Name;
                messageText += "<p> Boas vindas ao ShopTrybe</p>";

                Message message = new Message {
                    Title = "Shop Trybe - Cadastro realizado",
                    Text = messageText,
                    MailTo = user.Email
                };
                _notificationService.Send(message);

                _logger.LogInformation("New user created");

                return Created("", new { token = AuthService.GenerateToken(userCreated)} );
            }
            catch (Exception ex) {
                _logger.LogError(message: ex.Message.ToString(), ex);
                return BadRequest( new { message = ex.Message.ToString() });
            }
            
        }
}

