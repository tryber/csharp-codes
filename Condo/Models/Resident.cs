using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  Condo.Models;

public class Resident
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("UnityId")]
    public int UnityId { get; set; }
    [ForeignKey("PersonId")]
    public int PersonId { get; set; }
    public Unity? Unity { get; set; }
    public Person? Person { get; set; }

}