using Condo.Models;

namespace Condo.Repository.Interfaces;

public interface ICondominiumRepository
{
    IEnumerable<Condominium> Get();
    Condominium Add(Condominium condominium);
    Condominium GetById(int Id);
    Condominium Update(int Id, Condominium condominium);
    void Delete(int Id);
}