namespace colecoes.test;
using colecoes;
using Xunit;
using FluentAssertions;

public class UnitTest1
{
    public static TheoryData<City[], State[], dynamic[]> TestData = new TheoryData<City[], State[], dynamic[]>
    {
        {
            new City[] {
              new City { Name="Belém", StateAbbreviation="PA" },
              new City { Name="Santarém", StateAbbreviation="PA" },
              new City { Name="Rio Branco", StateAbbreviation="AC" },
              new City { Name="Maceió", StateAbbreviation="AL" },
            },
            new State[] {
              new State { Name="Pará", Abbreviation="PA", Region="Norte" },
              new State { Name="Acre", Abbreviation="AC", Region="Norte" },
              new State { Name="Alagoas", Abbreviation="AL", Region="Nordeste" },
            },
            new[] {
              new { StateAbbreviation = "PA", NumberOfCities = 2 },
              new { StateAbbreviation = "AC", NumberOfCities = 1 },
              new { StateAbbreviation = "AL", NumberOfCities = 1 },
            }
        },
    };

    [Theory(DisplayName = "GetNumberOfCitiesForEachState deveria retornar o número de cidades para cada estado")]
    [MemberData(nameof(TestData))]
    public void TestGetNumberOfCitiesForEachState(City[] citiesEntry, State[] statesEntry, dynamic[] expected)
    {
        var instance = new Brazil();
            instance.cities = citiesEntry;
        instance.states = statesEntry;
        var result = instance.GetNumberOfCitiesForEachState();
        result.Should().BeEquivalentTo(expected);
    }

}