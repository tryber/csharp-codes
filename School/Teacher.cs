namespace School;
using System.ComponentModel.DataAnnotations;

public class Teacher
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public ICollection<Student>? Students { get; set; }
}