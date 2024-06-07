using AutoMapper;
using Condo.DTOs;
using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.UseCases.Interfaces;

namespace Condo.UseCases.AccessControl.CreateAccessRelease;

public class CreateAccessRelease : ICreateAccessRelease
{
    protected readonly IAccessRepository _repository;
    protected readonly ICreatePerson _createPersonUseCase;
    protected readonly IMapper _mapper;
    public CreateAccessRelease(IAccessRepository repository, ICreatePerson createPersonUseCase,  IMapper mapper)
    {
        _repository = repository;
        _createPersonUseCase = createPersonUseCase;
        _mapper = mapper;
    }
    public AccessResponseDTO Execute(AccessCreateDTO accessCreateDTO)
    {
        Person person = new Person {
            Name = accessCreateDTO.Name,
            Document = accessCreateDTO.Document
        };
        int myPersonId = _createPersonUseCase.Execute(person);

        Access newAccess = new Access {
            UnityId = accessCreateDTO.UnityId,
            PersonId = myPersonId,
            Date = accessCreateDTO.Date
        };
        return _mapper.Map<Access, AccessResponseDTO>(_repository.Add(newAccess));
    }
}
