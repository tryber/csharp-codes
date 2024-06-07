using Condo.DTOs;
using Condo.Models;

namespace Condo.UseCases.Interfaces;

public interface IUnityUseCase
{
    IEnumerable<UnityResponseDTO> Get();
    UnityResponseDTO GetById(int id);
    UnityResponseDTO Add(Unity unity);
    UnityResponseDTO Update(int id, Unity unity);
    void Delete(int id);
}