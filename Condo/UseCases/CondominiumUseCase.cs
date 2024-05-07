namespace Condo.UseCases;
using Condo.UseCases.Interfaces;
using Condo.Repository.Interfaces;
using Condo.Models;
using AutoMapper;
using Condo.DTOs;

public class CondominiumUseCase : ICondominiumUseCase
{
    protected readonly ICondominiumRepository _repository;
    protected readonly IMapper _mapper;
    public CondominiumUseCase(ICondominiumRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public IEnumerable<CondominiumResponseDTO> Get()
    {
        return _mapper.Map<IEnumerable<CondominiumResponseDTO>>(_repository.Get());
    }
    public Condominium Add(Condominium condominium)
    {
        return _repository.Add(condominium);
    }

    public CondominiumResponseDTO GetById(int Id)
    {
        return _mapper.Map<CondominiumResponseDTO>(_repository.GetById(Id));
    }

    public Condominium Update(int Id, Condominium condominium)
    {
        return _repository.Update(Id, condominium);
    }

    public void Delete(int Id)
    {
        _repository.Delete(Id);
    }
}