namespace colecoes;

internal class Book
{
    public string? title { get; set; }
    public int price { get; set; }
    public int publishYear { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        var books = new List<Book>
        {
            new Book { title = "The Count of Monte Cristo", price = 39, publishYear = 2002 },
            new Book { title = "Brave new World ", price = 32, publishYear = 1932 },
            new Book { title = "The Hobbit", price = 35, publishYear = 2011 },
            new Book { title = "Pan's Labyrinth: The Labyrinth of the Faun", price = 25, publishYear = 2019 },
            new Book { title = "Throne of Glass", price = 29, publishYear = 2013 },
        };

        var booksAfter2000 = from book in books
                           where book.price > 30
                           select book.title;

        foreach(var book in booksAfter2000)
        {
            Console.WriteLine(book);
        }
    }
}