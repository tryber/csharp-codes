using AutoMapper;
using Condo.DTOs;
using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.UseCases.Interfaces;

namespace Condo.UseCases;

public class ResidentUseCase : IResidentUseCase
{
    protected readonly IResidentRepository _repository;
    protected readonly ICreatePerson _createPerson;
    protected readonly IMapper _mapper;
    public ResidentUseCase(IResidentRepository repository, ICreatePerson createPerson,  IMapper mapper)
    {
        _repository = repository;
        _createPerson = createPerson;
        _mapper = mapper;
    }

    public ResidentResponseDTO Add(ResidentCreateDTO residentCreate)
    {
         Person newPerson = new Person {
            Name = residentCreate.Name,
            Document = residentCreate.Document
        };

        int myPersonId = _createPerson.Execute(newPerson);

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