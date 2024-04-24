namespace School;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{
    [Key]
    public int Id { get; set;}
    public string? Name { get; set; }
    public string? Course { get; set;}
    [ForeignKey("TeacherId")]
    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
}