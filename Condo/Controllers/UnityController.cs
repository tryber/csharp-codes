using Condo.Models;
using Condo.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condo.Controllers;

[ApiController]
[Route("[controller]")]
public class UnityController : ControllerBase
{
    protected readonly IUnityUseCase _useCase;
    public UnityController(IUnityUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_useCase.Get());
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok(_useCase.GetById(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Unity unity)
    {
        return Created("", _useCase.Add(unity));
    }

    [HttpPut("{id:int}")]
    public IActionResult Put(int id, [FromBody] Unity unity)
    {
        return Ok(_useCase.Update(id, unity));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        _useCase.Delete(id);
        return NoContent();
    }
}