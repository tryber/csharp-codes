using Condo.DTOs;

namespace Condo.UseCases.Interfaces;

public interface ICreateAccessRelease
{
    AccessResponseDTO Execute(AccessCreateDTO accessCreateDTO);
}