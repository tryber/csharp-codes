using Condo.Types;

namespace Condo.DTOs;

public class CondominiumResponseDTO
{
     public int Id { get; set; }
    public string? Name { get; set; }
    public CondoType Type { get; set; }
    public double PropertyTax { get; set; }
    public List<UnityResponseDTO>? Units { get; set; }
}

public class CondominiumResidentResponseDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public CondoType Type { get; set; }
}
