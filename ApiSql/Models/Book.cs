namespace ApiSql.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{
    [Key]
    public int BookId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Genre { get; set; }
    public int Year { get; set; }
    public int Pages { get; set; }
    [ForeignKey("AuthorId")]
    public int? AuthorId { get; set; }
     public Author Author { get; set; }
     [ForeignKey("PublisherId")]
    public int? PublisherId { get; set; }
    public Publisher Publisher { get; set; }
}