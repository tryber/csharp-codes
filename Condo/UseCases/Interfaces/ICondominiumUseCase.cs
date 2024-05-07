using Condo.DTOs;
using Condo.Models;

namespace Condo.UseCases.Interfaces;

public interface ICondominiumUseCase
{
    IEnumerable<CondominiumResponseDTO> Get();
    Condominium Add(Condominium condominium);
    CondominiumResponseDTO GetById(int Id);
    Condominium Update(int Id, Condominium condominium);
    void Delete(int Id);
}