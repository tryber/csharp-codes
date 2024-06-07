using Condo.DTOs;

namespace Condo.UseCases.Interfaces;

public interface IGetAccessReleaseById
{
     AccessResponseDTO Execute(int id);
}