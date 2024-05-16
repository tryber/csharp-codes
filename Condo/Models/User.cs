using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Condo.Types;

namespace Condo.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public UserType Type { get; set; }
    [ForeignKey("PersonId")]
    public int PersonId { get; set; }
    public Person? Person { get; set; }
    public string? VerificationCode { get; set; }

}