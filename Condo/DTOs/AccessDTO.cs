
using Condo.Types;

namespace Condo.DTOs;

public class AccessCreateDTO : ResidentCreateDTO
{
    public DateTime Date { get; set; }
}

public class AccessResponseDTO : ResidentResponseDTO
{
    public DateTime Date { get; set; }
    public AccessStatus Status { get; set; }
}

public class AccessPatchDTO
{
    public AccessStatus Status { get; set; }
}