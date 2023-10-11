namespace colecoes;

internal class Artist
{
    public string? name { get; set; }
    public int listeners { get; set; }
}

public class Program
{
    public static void Main(string[] args)
    {
        var artists = new List<Artist>
        {
            new Artist { name = "Raul Seixas", listeners = 50000 },
            new Artist { name = "Mozart", listeners = 15000 },
            new Artist { name = "Elvis Presley", listeners = 25000 },
            new Artist { name = "Bob Dylan", listeners = 30000 },
            new Artist { name = "Guns N' Roses", listeners = 40000 },
        };

        var topListeners =
               from artist in artists
               where artist.listeners > 30000
               select artist.name;

        foreach(var artist in topListeners)
        {
            Console.WriteLine(artist);
        }
    }
}