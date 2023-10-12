namespace colecoes;

public class State
{
    public string? Name { get; set; }
    public string? Abbreviation { get; set;}
    public string? Region { get; set; }
}

public class City
{
    public string? Name { get; set; }
    public string? StateAbbreviation { get; set;}
}
public class Brazil
{
    public State[] states;
    public City[] cities;

    public dynamic[] GetNumberOfCitiesForEachState()
    {
        var numberOfCitiesForEachState =
            from state in states
            join city in cities on state.Abbreviation equals city.StateAbbreviation
            group city by state.Abbreviation into stateGroup
            select new {
                StateAbbreviation = stateGroup.Key,
                NumberOfCities = stateGroup.Count()
            };

        return numberOfCitiesForEachState.ToArray();
    }
}
public class Program
{
    public static void Main(string[] args)
    {
    }
}
