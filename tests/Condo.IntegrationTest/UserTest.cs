namespace Condo.IntegrationTest;
using Condo.Types;
using Newtonsoft.Json;
using Condo.DTOs;
using System.Net;
using Condo.Context;
using Condo.Context.Interfaces;
using Condo.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Condo.UseCases.Interfaces;
using System.IdentityModel.Tokens.Jwt;

public class MessageResponse
{
    public string? message { get; set; }
}
public class UserTest : IClassFixture<WebApplicationFactory<Program>>
{
    private HttpClient _client;
    private Mock<ISendEmail> _mockSendEmail;
    public UserTest(WebApplicationFactory<Program> factory)
    {
        _mockSendEmail = new Mock<ISendEmail>();

        _client = factory.WithWebHostBuilder(builder => {
            builder.ConfigureServices(services => {
                var descriptorSendMail = services.SingleOrDefault(service => service.ServiceType == typeof(ISendEmail));
                if (descriptorSendMail != null)
                {
                    services.Remove(descriptorSendMail);
                }
                services.AddSingleton(_mockSendEmail.Object);
                
                var descriptor = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<DatabaseContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<ContextTest>(options => {
                    options.UseInMemoryDatabase("InMemoryDatabaseUser");
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



    [Trait("Category", "Test Post User")]
    [Theory(DisplayName = "Check Post User")]
    [InlineData("/user")]
    public async Task Test_PostUser(string url)
    {
        _mockSendEmail.Setup(m => m.Execute(It.IsAny<MailMessage>())).Verifiable();

         var inputLogin = new {
            Email = "maria@email.com",
            Password = "SenhaForte123*"
        };

        var responseLogin = await _client.PostAsync("/login", new StringContent(JsonConvert.SerializeObject(inputLogin), System.Text.Encoding.UTF8, "application/json"));
        var responseLoginString = await responseLogin.Content.ReadAsStringAsync();
        LoginResponseDTO loginResponseDTO = JsonConvert.DeserializeObject<LoginResponseDTO>(responseLoginString)!;

        var inputObj = new {
            Name = "Rodrigo Costa",
            Email = "rodrigo.costa@email.com",
            UserType = 0,
            Document = "48.752.666-9"
        };
        
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", loginResponseDTO.Token);
        var response = await _client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(inputObj), System.Text.Encoding.UTF8, "application/json"));
        var responseString = await response.Content.ReadAsStringAsync();
        UserCreatedResponseDTO userCreatedResponseDTO = JsonConvert.DeserializeObject<UserCreatedResponseDTO>(responseString)!;

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        Assert.Contains("rodrigo.costa@email.com", userCreatedResponseDTO.Email);

        var inputObjVerify = new {
            Email = "rodrigo.costa@email.com",
            userCreatedResponseDTO.VerificationCode,
            NewPassword = "SenhaForte123*",
            ConfirmPassword = "SenhaForte123*",
        };

        var responseVerify = await _client.PostAsync(url+"/verify", new StringContent(JsonConvert.SerializeObject(inputObjVerify), System.Text.Encoding.UTF8, "application/json"));
        var responseVerifyString = await responseVerify.Content.ReadAsStringAsync();
        MessageResponse messageResponse = JsonConvert.DeserializeObject<MessageResponse>(responseVerifyString)!;

        Assert.Equal(HttpStatusCode.OK, responseVerify.StatusCode);
        Assert.Contains("User verified", messageResponse.message);

         var inputObjLogin = new {
            Email = "rodrigo.costa@email.com",
            Password = "SenhaForte123*"
        };

        var responseLoginUser = await _client.PostAsync("/login", new StringContent(JsonConvert.SerializeObject(inputObjLogin), System.Text.Encoding.UTF8, "application/json"));
        var responseLoginUserString = await responseLoginUser.Content.ReadAsStringAsync();
        LoginResponseDTO loginResponseUserDTO = JsonConvert.DeserializeObject<LoginResponseDTO>(responseLoginUserString)!;

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadToken(loginResponseUserDTO.Token!) as JwtSecurityToken;
        var tokenEmail = token!.Claims.FirstOrDefault(claim => claim.Type == "email")!.Value;

        Assert.Contains("rodrigo.costa@email.com", tokenEmail);
    }
}
