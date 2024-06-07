using AutoMapper;
using Condo.DTOs;
using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.UseCases.Interfaces;

namespace Condo.UseCases.AccessControl.GetAccessReleaseById;

public class GetAccessReleaseById : IGetAccessReleaseById
{
     protected readonly IAccessRepository _repository;
    protected readonly IMapper _mapper;
    public GetAccessReleaseById(IAccessRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public AccessResponseDTO Execute(int id)
    {
        return _mapper.Map<Access, AccessResponseDTO>(_repository.GetById(id));
    }
}