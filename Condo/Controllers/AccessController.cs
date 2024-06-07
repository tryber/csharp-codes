using Condo.DTOs;
using Condo.UseCases.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AccessController : ControllerBase
{
    protected readonly ICreateAccessRelease _createAccessReleaseUseCase;
    protected readonly IChangeAccessRelease _changeAccessReleaseUseCase;
    protected readonly IGetAccessReleaseByCondominium _getAccessReleaseByCondominium;
    protected readonly IGetAccessReleaseById _getAccessReleaseById;

    public AccessController(ICreateAccessRelease createAccessReleaseUseCase, 
                            IChangeAccessRelease changeAccessReleaseUseCase, 
                            IGetAccessReleaseByCondominium getAccessReleaseByCondominium,
                            IGetAccessReleaseById getAccessReleaseById)
    {
        _createAccessReleaseUseCase = createAccessReleaseUseCase;
        _changeAccessReleaseUseCase = changeAccessReleaseUseCase;
        _getAccessReleaseByCondominium = getAccessReleaseByCondominium;
        _getAccessReleaseById = getAccessReleaseById;
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "Resident")]
    public IActionResult Add([FromBody] AccessCreateDTO accessCreateDTO)
    {
        return Created("", _createAccessReleaseUseCase.Execute(accessCreateDTO));
    }

    [HttpPatch("{id:int}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "Employee")]
    public IActionResult ChangeStatus([FromBody] AccessPatchDTO accessPatchDTO, int id)
    {
        return Ok(_changeAccessReleaseUseCase.Execute(id, accessPatchDTO));
    }

    [HttpGet("{id:int}")]
    public IActionResult Get(int id)
    {
        return Ok(_getAccessReleaseById.Execute(id));
    }

    [HttpGet("condominium/{CondominiumId:int}")]
    public IActionResult GetByCondominium(int CondominiumId)
    {
        return Ok(_getAccessReleaseByCondominium.Execute(CondominiumId));
    }




}