namespace colecoes;

public class Program
{
    public static void Main(string[] args)
    {
        var games = new List<List<string>>
        {
            new List<string> { "Valorant", "CS GO", "Battlefield" },
            new List<string> { "Need For Speed", "The crew" },
            new List<string> { "League of Legends", "Dota" }
        };

        var gamesInLine = from gameLine in games
                          from game in gameLine
                          select game;
                
        foreach(string game in gamesInLine)
        {
            Console.WriteLine(game);
        }

    }
}