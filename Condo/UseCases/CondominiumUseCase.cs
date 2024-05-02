namespace Condo.UseCases;
using Condo.UseCases.Interfaces;
using Condo.Repository.Interfaces;
using Condo.Models;

public class CondominiumUseCase : ICondominiumUseCase
{
    protected readonly ICondominiumRepository _repository;
    public CondominiumUseCase(ICondominiumRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Condominium> Get()
    {
        return _repository.Get();
    }
    public Condominium Add(Condominium condominium)
    {
        return _repository.Add(condominium);
    }
}