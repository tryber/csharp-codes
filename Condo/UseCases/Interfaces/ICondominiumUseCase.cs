using Condo.Models;

namespace Condo.UseCases.Interfaces;

public interface ICondominiumUseCase
{
    IEnumerable<Condominium> Get();
    Condominium Add(Condominium condominium);
    Condominium GetById(int Id);
    Condominium Update(int Id, Condominium condominium);
    void Delete(int Id);
}