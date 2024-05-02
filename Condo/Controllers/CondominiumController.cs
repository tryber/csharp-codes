using Condo.Models;
using Condo.UseCases.Interfaces;
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
    public IActionResult Post([FromBody] Condominium condominium)
    {
        return Created("", _useCase.Add(condominium));
    }
}