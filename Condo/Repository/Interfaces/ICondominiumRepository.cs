using Condo.Models;

namespace Condo.Repository.Interfaces;

public interface ICondominiumRepository
{
    IEnumerable<Condominium>Get();
    Condominium Add(Condominium condominium);
}