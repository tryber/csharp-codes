using Mail.API.Models;
using Mail.API.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace Mail.API.Controllers;

[ApiController]
[Route("[controller]")]
public class MailController : ControllerBase
{
    protected readonly ISendMail _sendMail;
    public MailController(ISendMail sendMail)
    {
        _sendMail = sendMail;
    }

    [HttpPost("send")]
    public IActionResult Send([FromBody] Message message)
    {
        try
        {
            _sendMail.Execute(message);
            return Ok(new { Message = "Mail sent"});
        }
        catch(Exception ex)
        {
            return BadRequest( new { Message = ex.Message });
        }
    }
}