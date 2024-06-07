using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Condo.Types;

namespace Condo.Models;

public class Access
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("UnityId")]
    public int UnityId { get; set; }
    [ForeignKey("PersonId")]
    public int PersonId { get; set; }
    public DateTime Date { get; set; }
    public AccessStatus Status { get; set; }
    public Person? Person { get; set; }
    public Unity? Unity { get; set; }
}