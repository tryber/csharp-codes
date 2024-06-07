using Condo.DTOs;
using Condo.Models;

namespace Condo.UseCases.Interfaces;

public interface IResidentUseCase
{
    ResidentResponseDTO Add(ResidentCreateDTO residentCreate);
    IEnumerable<ResidentResponseDTO> GetByUnit(int UnityId);
    IEnumerable<ResidentResponseDTO> GetByCondominium(int CondominiumId);
    ResidentResponseDTO GetById(int id);
    
}