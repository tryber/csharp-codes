using Condo.Types;

namespace  Condo.Models;

public class Condominium
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public CondoType Type { get; set; }
    public double PropertyTax { get; set; }
}