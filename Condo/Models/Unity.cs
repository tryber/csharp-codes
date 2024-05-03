using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  Condo.Models;

public class Unity
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    [ForeignKey("CondominiumId")]
    public int CondominiumId { get; set; }
    public Condominium? Condominium { get; set; }
    public List<Resident>? Residents { get; set; }
}