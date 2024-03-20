namespace Movies;

public class MoviePrincipal
{
    public static void Main(string[] args)
    {
        Movie movieA = new Movie("Matrix", "Ficção científica");
        Movie movieB = new Movie("Senhor dos Anéis", "Fantasia");

        movieA.Title = "Matrix 2";
        movieA.Category = "Ficção científica";

        Console.WriteLine(movieA.Title);
        Console.WriteLine(movieA.Category);
    }
}
