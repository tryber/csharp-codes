using Condo.DTOs;

namespace Condo.UseCases.Interfaces;

public interface IGetAccessReleaseByCondominium
{
    IEnumerable<AccessResponseDTO> Execute(int CondominiumId);
}