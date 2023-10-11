namespace colecoes;
public class Program
{
    public static void Main(string[] args)
    {
        string[] games = {"Fortnite", "Valorant", "Destiny", "Call of Duty", "World of Warcraft"};

        IEnumerable<string> filteredGames = from game in games
                                          where game.Contains('a')
                                          select game;
        foreach(var game in filteredGames)
        {
            Console.WriteLine(game);
        }
    }
}