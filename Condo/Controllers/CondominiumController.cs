using Condo.Models;
using Condo.UseCases.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Condo.Controllers;

[ApiController]
[Route("[controller]")]
public class CondominiumController : ControllerBase
{
    protected readonly ICondominiumUseCase _useCase;
    public CondominiumController(ICondominiumUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_useCase.Get());
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "Administrator")]
    public IActionResult Post([FromBody] Condominium condominium)
    {
        return Created("", _useCase.Add(condominium));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok(_useCase.GetById(id));
    }

    [HttpPut("{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "Administrator")]
    public IActionResult Put(int id, [FromBody] Condominium condominium)
    {
        return Ok(_useCase.Update(id, condominium));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _useCase.Delete(id);
        return NoContent();
    }






}