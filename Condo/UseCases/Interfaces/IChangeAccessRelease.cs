using Condo.DTOs;

namespace Condo.UseCases.Interfaces;

public interface IChangeAccessRelease
{
    AccessResponseDTO Execute(int id, AccessPatchDTO accessPatchDTO);
}