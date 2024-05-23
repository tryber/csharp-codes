using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  Condo.Models;

public class Person
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Document { get; set; }
    public List<Resident>? Residents { get; set; }
}