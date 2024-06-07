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
    protected readonly ISendAccessCreatedMail _sendAccessCreatedMail;
    protected readonly IMapper _mapper;
    public CreateAccessRelease(IAccessRepository repository, ISendAccessCreatedMail sendAccessCreatedMail, ICreatePerson createPersonUseCase,  IMapper mapper)
    {
        _repository = repository;
        _createPersonUseCase = createPersonUseCase;
        _mapper = mapper;
        _sendAccessCreatedMail = sendAccessCreatedMail;
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
        AccessResponseDTO accessResponseDTO = _mapper.Map<Access, AccessResponseDTO>(_repository.Add(newAccess));
        _sendAccessCreatedMail.Execute(accessResponseDTO);
        return accessResponseDTO;
    }
}
