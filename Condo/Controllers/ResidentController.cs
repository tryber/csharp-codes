using Condo.DTOs;
using Condo.Models;
using Condo.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Condo.Controllers;

[ApiController]
[Route("[controller]")]
public class ResidentController : ControllerBase
{
    protected readonly IResidentUseCase _useCase;

    public ResidentController(IResidentUseCase useCase)
    {
        _useCase = useCase;
    }


    [HttpPost]
    public IActionResult Post([FromBody] ResidentCreateDTO resident)
    {
        return Created("", _useCase.Add(resident));
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok(_useCase.GetById(id));
    }


    [HttpGet("unity/{UnityId:int}")]
    public IActionResult GetByUnitId(int UnityId)
    {
        return Ok(_useCase.GetByUnit(UnityId));
    }

    [HttpGet("condominium/{CondominiumId:int}")]
    public IActionResult GetByCondominiumId(int CondominiumId)
    {
        return Ok(_useCase.GetByCondominium(CondominiumId));
    }

    
}
