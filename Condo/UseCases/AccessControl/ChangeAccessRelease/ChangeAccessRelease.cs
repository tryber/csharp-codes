using AutoMapper;
using Condo.DTOs;
using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.UseCases.Interfaces;

namespace Condo.UseCases.AccessControl.ChangeAccessRelease;

public class ChangeAccessRelease : IChangeAccessRelease
{
     protected readonly IAccessRepository _repository;
    protected readonly IMapper _mapper;
    public ChangeAccessRelease(IAccessRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public AccessResponseDTO Execute(int id, AccessPatchDTO accessPatchDTO)
    {
        return _mapper.Map<Access, AccessResponseDTO>(_repository.ChangeStatus(id, accessPatchDTO.Status));
    }
}