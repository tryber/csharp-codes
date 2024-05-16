namespace Condo.UseCases;
using Condo.UseCases.Interfaces;
using Condo.Repository.Interfaces;
using Condo.Models;
using System.Collections.Generic;
using Condo.DTOs;
using AutoMapper;

public class UnityUseCase : IUnityUseCase
{
    protected readonly IUnityRepository _repository;
    protected readonly IMapper _mapper;
    public UnityUseCase(IUnityRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public UnityResponseDTO Add(Unity unity)
    {
        return _mapper.Map<UnityResponseDTO>(_repository.Add(unity));
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    public IEnumerable<UnityResponseDTO> Get()
    {
        return _mapper.Map<IEnumerable<UnityResponseDTO>>(_repository.Get());
    }

    public UnityResponseDTO GetById(int id)
    {
        return _mapper.Map<UnityResponseDTO>(_repository.GetById(id));
    }

    public UnityResponseDTO Update(int id, Unity unity)
    {
        return _mapper.Map<UnityResponseDTO>(_repository.Update(id, unity));
    }
}