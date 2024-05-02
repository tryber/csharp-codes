using Condo.Models;

namespace Condo.UseCases.Interfaces;

public interface ICondominiumUseCase
{
    IEnumerable<Condominium> Get();
    Condominium Add(Condominium condominium);
}