using AutoMapper;
using Condo.DTOs;
using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.UseCases.Interfaces;

namespace Condo.UseCases;

public class ResidentUseCase : IResidentUseCase
{
    protected readonly IResidentRepository _repository;
    protected readonly IPersonRepository _personRepository;
    protected readonly IMapper _mapper;
    public ResidentUseCase(IResidentRepository repository, IPersonRepository personRepository,  IMapper mapper)
    {
        _repository = repository;
        _personRepository = personRepository;
        _mapper = mapper;
    }

    public ResidentResponseDTO Add(ResidentCreateDTO residentCreate)
    {
        int myPersonId;

        Person? existingPerson = _personRepository.GetByDocument(residentCreate.Document!);
        if (existingPerson != null) {
            myPersonId = existingPerson.Id;
        } else {
            Person newPerson = new Person {
                Name = residentCreate.Name,
                Document = residentCreate.Document
            };
            Person createdPerson = _personRepository.Add(newPerson);
            myPersonId = createdPerson.Id;
        }

        Resident resident = new Resident {
            UnityId = residentCreate.UnityId,
            PersonId = myPersonId
        };
        return _mapper.Map<ResidentResponseDTO>(_repository.Add(resident));
    }

    public IEnumerable<ResidentResponseDTO> GetByCondominium(int CondominiumId)
    {
        return _mapper.Map<IEnumerable<Resident>, IEnumerable<ResidentResponseDTO>>(_repository.GetByCondominium(CondominiumId));
    }

    public ResidentResponseDTO GetById(int id)
    {
        return _mapper.Map<Resident, ResidentResponseDTO>(_repository.GetById(id));
    }

    public IEnumerable<ResidentResponseDTO> GetByUnit(int UnityId)
    {
        return _mapper.Map<IEnumerable<Resident>, IEnumerable<ResidentResponseDTO>>(_repository.GetByUnit(UnityId));
    }
}