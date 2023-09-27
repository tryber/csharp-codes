namespace ContactList.Test;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using ContactList.Controllers;
using Newtonsoft.Json;
using ContactList.Models;
using Moq;
using ContactList.Services;
using Microsoft.Extensions.DependencyInjection;

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
        Person[] personMoq = new Person[2];
        personMoq[0] = new Person { PersonId = 1, PersonName = "Maria", PersonEmail = "maria@betrybe.com", PersonPhone = "5511999999999"};
        personMoq[1] = new Person { PersonId = 2, PersonName = "João", PersonEmail = "joao@betrybe.com", PersonPhone = "5511988888888"};

        mockService.Setup(s => s.getPersonList()).Returns(personMoq);

        var response = await _clientTest.GetAsync(url);
        var responseString = await response.Content.ReadAsStringAsync();
        Person[] jsonResponse = JsonConvert.DeserializeObject<Person[]>(responseString)!;

        Assert.Equal(System.Net.HttpStatusCode.OK, response?.StatusCode);
        Assert.Equal(2, jsonResponse.Count()!);
        Assert.Equal(personMoq[0].PersonName, jsonResponse[0].PersonName);
    }   

    [Theory(DisplayName = "Testando a rota /POST Person")]
    [InlineData("/person")]
    public async Task TestCreatePerson(string url)
    {
        Person personMoq = new Person { PersonId = 3, PersonName = "Rebeca", PersonEmail = "rebeca@betrybe.com", PersonPhone = "5511977777777"};
        mockService.Setup(s => s.addPerson(It.IsAny<Person>())).Returns(personMoq);

        var inputObj = new {
            PersonName = "Rebeca",
            PersonEmail = "rebeca@betrybe.com",
            PersonPhone = "5511977777777"
        };
        var response = await _clientTest.PostAsync(url, new StringContent(JsonConvert.SerializeObject(inputObj), System.Text.Encoding.UTF8, "application/json"));
        var responseString = await response.Content.ReadAsStringAsync();
        Person jsonResponse = JsonConvert.DeserializeObject<Person>(responseString)!;

        Assert.Equal(System.Net.HttpStatusCode.Created, response?.StatusCode);
        Assert.Equal(personMoq.PersonId, jsonResponse.PersonId);
        Assert.Equal(personMoq.PersonName, jsonResponse.PersonName);
        Assert.Equal(personMoq.PersonPhone, jsonResponse.PersonPhone);
        Assert.Equal(personMoq.PersonEmail, jsonResponse.PersonEmail);
    }
}