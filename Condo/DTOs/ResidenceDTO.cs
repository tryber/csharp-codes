namespace Condo.DTOs;

public class ResidentCreateDTO
{
    public int UnityId { get; set; }
    public string? Name { get; set; }
    public string? Document { get; set; }
}

public class ResidentResponseDTO
{
    public UnityResponseDTO? Unity { get; set; }
    public PersonResponseDTO? Person { get; set; }
    public CondominiumResidentResponseDTO? Condominium { get; set; }
}