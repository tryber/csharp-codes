namespace TestApi.Test;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using TestApi.Controllers;


public class IntegrationTest: IClassFixture<WebApplicationFactory<Program>>
{
    public HttpClient _clientTest;

    public IntegrationTest(WebApplicationFactory<Program> factory)
    {
        _clientTest = factory.CreateClient();
    }
    

    [Theory(DisplayName = "Testando a rota /GET Clients")]
    [InlineData("/clients")]
    public async Task TestGetClients(string url)
    {
        var response = await _clientTest.GetAsync(url);
        Assert.Equal(System.Net.HttpStatusCode.OK, response?.StatusCode);
    }
}