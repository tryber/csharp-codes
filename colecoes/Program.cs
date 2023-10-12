namespace colecoes;

public class Author
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class Book
{
    public string? Name { get; set; }
    public int AuthorId { get; set; }
}

public class BookDTO
{
    public string? BookName { get; set; }
    public string? AuthorName { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        List<Author> authors = new List<Author>
        {
            new Author { Id = 1, Name = "Clarice Lispector"},
            new Author { Id = 2, Name = "Jorge Amado" }
        };

        List<Book> books = new List<Book>
        {
            new Book { Name = "Capitães da Areia", AuthorId = 2},
            new Book { Name = "Água Viva", AuthorId = 1},
            new Book { Name = "A hora da Estrela", AuthorId = 1},
            new Book { Name = "Cacau", AuthorId = 2},
        };

        var booksList = from book in books
                        from author in authors
                        where author.Id == book.AuthorId
                        orderby author.Name
                        select new BookDTO { BookName = book.Name, AuthorName = author.Name };

        foreach (BookDTO book in booksList)
        {
            Console.WriteLine(book.BookName + " - Author: " + book.AuthorName);
        }
    }
}