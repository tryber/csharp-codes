using Condo.DTOs;

namespace Condo.UseCases.Interfaces;

public interface ISendAccessCreatedMail
{
    void Execute(AccessResponseDTO accessResponseDTO);
}