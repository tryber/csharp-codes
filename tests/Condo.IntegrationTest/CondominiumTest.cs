using Condo.Context;
using Condo.Context.Interfaces;
using Condo.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Condo.Types;
using Newtonsoft.Json;
using Condo.DTOs;
using System.Net;

namespace Condo.IntegrationTest;

public class CondominiumTest : IClassFixture<WebApplicationFactory<Program>>
{
    private HttpClient _client;
    public CondominiumTest(WebApplicationFactory<Program> factory)
    {
        _client = factory.WithWebHostBuilder(builder => {
            builder.ConfigureServices(services => {
                var descriptor = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<DatabaseContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<ContextTest>(options => {
                    options.UseInMemoryDatabase("InMemoryDatabase");
                });

                services.AddScoped<IDatabaseContext, ContextTest>();

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                using (var appContext = scope.ServiceProvider.GetRequiredService<ContextTest>())
                {
                    appContext.Database.EnsureCreated();
                    appContext.Database.EnsureDeleted();
                    appContext.Database.EnsureCreated();

                    appContext.Person.Add(new Person {Id = 1, Name = "Maria", Document = "99.750.795-3"});
                    appContext.Person.Add(new Person {Id = 2, Name = "Luiza", Document = "48.198.304-2"});

                    appContext.Person.Add(new Person {Id = 3, Name = "Victor", Document = "44.326.634-6"});
                    appContext.Person.Add(new Person {Id = 4, Name = "Pedro", Document = "64.674.501-2"});
                    appContext.Person.Add(new Person {Id = 5, Name = "Julia", Document = "98.047.209-5"});
                    appContext.Person.Add(new Person {Id = 6, Name = "Marcia", Document = "48.602.195-8"});
                    appContext.Person.Add(new Person {Id = 7, Name = "Paulo", Document = "69.859.131-2"});
                    appContext.Person.Add(new Person {Id = 8, Name = "Daniel", Document = "66.735.429-8"});
                    appContext.Person.Add(new Person {Id = 9, Name = "Francisco", Document = "62.741.476-2"});

                    appContext.SaveChanges();

                    appContext.Users.Add(new User { Id = 1, Name = "Maria", Email = "maria@email.com", Password = "$2y$04$0aSxdy0z75mb8t18jPfKxOtAbb3JApCEZpMTWO6nH6N0YvfnWWBri", Type = UserType.Administrator, VerificationCode = "", PersonId = 1 });
                    appContext.Users.Add(new User { Id = 2, Name = "Luiza", Email = "luiza@email.com", Password = "$2y$04$0aSxdy0z75mb8t18jPfKxOtAbb3JApCEZpMTWO6nH6N0YvfnWWBri", Type = UserType.Employee, VerificationCode = "", PersonId = 2 });
                    appContext.Users.Add(new User { Id = 3, Name = "Victor", Email = "victor@email.com", Password = "$2y$04$0aSxdy0z75mb8t18jPfKxOtAbb3JApCEZpMTWO6nH6N0YvfnWWBri", Type = UserType.Resident, VerificationCode = "", PersonId = 3 });
                    appContext.SaveChanges();

                    appContext.Condominiums.Add(new Condominium { Id = 1, Name = "Residencial Europa", Type = CondoType.Residential, PropertyTax = 540.97 });
                    appContext.Condominiums.Add(new Condominium { Id = 2, Name = "Edifício Bela Vista", Type = CondoType.Commercial, PropertyTax = 2819.50 });
                    appContext.SaveChanges();

                    appContext.Unities.Add(new Unity { Id = 1, Name = "Ap 100", CondominiumId = 1 });
                    appContext.Unities.Add(new Unity { Id = 2, Name = "Ap 200", CondominiumId = 1 });
                    appContext.Unities.Add(new Unity { Id = 3, Name = "Cj 10A", CondominiumId = 2 });
                    appContext.Unities.Add(new Unity { Id = 4, Name = "Cj 10B", CondominiumId = 2 });
                    appContext.SaveChanges();

                    appContext.Residents.Add(new Resident { Id = 1, UnityId = 1, PersonId = 3 });
                    appContext.Residents.Add(new Resident { Id = 2, UnityId = 1, PersonId = 4 });
                    appContext.Residents.Add(new Resident { Id = 3, UnityId = 2, PersonId = 5 });
                    appContext.Residents.Add(new Resident { Id = 4, UnityId = 2, PersonId = 6 });
                    appContext.Residents.Add(new Resident { Id = 5, UnityId = 3, PersonId = 7 });
                    appContext.Residents.Add(new Resident { Id = 6, UnityId = 4, PersonId = 8 });
                    appContext.SaveChanges();

                    appContext.AccessControl.Add(new Access { Id = 1, UnityId = 3, PersonId = 9, Date = new DateTime(2024, 12, 15), Status = AccessStatus.Pending});
                    appContext.SaveChanges();
                }

            });
        }).CreateClient();
    }

    [Trait("Category", "Test GET Condominium")]
    [Theory(DisplayName = "Check Get Route")]
    [InlineData("/condominium")]
    public async Task Test_GetCondominium(string url)
    {
        var response = await _client.GetAsync(url);
        var responseString = await response.Content.ReadAsStringAsync();
        List<CondominiumResponseDTO> responseJson = JsonConvert.DeserializeObject<List<CondominiumResponseDTO>>(responseString)!;
        responseJson = responseJson.OrderBy(r => r.Id).ToList();

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("Residencial Europa", responseJson[0].Name);
        Assert.Equal(540.97, responseJson[0].PropertyTax);

        Assert.Equal("Edifício Bela Vista", responseJson[1].Name);
        Assert.Equal(2819.50, responseJson[1].PropertyTax);
    }


    [Trait("Category", "Test Post Condominium")]
    [Theory(DisplayName = "Check Get Route")]
    [InlineData("/condominium")]
    public async Task Test_PostCondominium(string url)
    {
        var inputLogin = new {
            Email = "maria@email.com",
            Password = "SenhaForte123*"
        };

        var responseLogin = await _client.PostAsync("/login", new StringContent(JsonConvert.SerializeObject(inputLogin), System.Text.Encoding.UTF8, "application/json"));
        var responseLoginString = await responseLogin.Content.ReadAsStringAsync();
        LoginResponseDTO loginResponseDTO = JsonConvert.DeserializeObject<LoginResponseDTO>(responseLoginString)!;
      
        var inputCondominium = new {
            Name = "Condominio Teste",
            Type = 0,
            PropertyValue = 600
        };

        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", loginResponseDTO.Token);
        var response = await _client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(inputCondominium), System.Text.Encoding.UTF8, "application/json"));
        var responseString = await response.Content.ReadAsStringAsync();
        Condominium responseJson = JsonConvert.DeserializeObject<Condominium>(responseString)!;
        
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.Contains("Condominio Teste", responseJson.Name);
    }
}