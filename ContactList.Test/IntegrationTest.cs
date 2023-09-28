namespace ContactList.Test;

using Moq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

using ContactList.Models;
using ContactList.Services;
using ContactList.Controllers;

public class IntegrationTest: IClassFixture<WebApplicationFactory<Program>>
{
    public HttpClient _clientTest;
    public Mock<IContactService> mockService;

    public IntegrationTest(WebApplicationFactory<Program> factory)
    {
         mockService = new Mock<IContactService>();

        _clientTest = factory.WithWebHostBuilder(builder => {
            builder.ConfigureServices(services => {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(IContactService));
                if (descriptor != null) 
                {
                    services.Remove(descriptor);
                }
                services.AddSingleton(mockService.Object);
            });
        }).CreateClient();
    }

    [Theory(DisplayName = "Testando a rota /GET Person")]
    [InlineData("/person")]
    public async Task TestGetPerson(string url)
    {
        // Arrange 

        Person[] personMoq = new Person[2];
        personMoq[0] = new Person { PersonId = 1, PersonName = "Maria", PersonEmail = "maria@betrybe.com", PersonPhone = "5511999999999"};
        personMoq[1] = new Person { PersonId = 2, PersonName = "João", PersonEmail = "joao@betrybe.com", PersonPhone = "5511988888888"};
        mockService.Setup(s => s.getPersonList()).Returns(personMoq);

        // Act

        var response = await _clientTest.GetAsync(url);
        var responseString = await response.Content.ReadAsStringAsync();
        Person[] jsonResponse = JsonConvert.DeserializeObject<Person[]>(responseString)!;

        // Assert

        Assert.Equal(System.Net.HttpStatusCode.OK, response?.StatusCode);
        Assert.Equal(2, jsonResponse.Count()!);
        Assert.Equal(personMoq[0].PersonId, jsonResponse[0].PersonId);
        Assert.Equal(personMoq[0].PersonName, jsonResponse[0].PersonName);
        Assert.Equal(personMoq[0].PersonPhone, jsonResponse[0].PersonPhone);
        Assert.Equal(personMoq[0].PersonEmail, jsonResponse[0].PersonEmail);
    }
}