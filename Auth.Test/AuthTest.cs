namespace Auth.Test;
using Moq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;
using Auth.Repository;
using Auth.Controllers;
using Auth.Models;

public class AuthTest
{
    
    [Theory]
    [InlineData("Luiz", "Trybes2")]
    [InlineData("Mayara", "Trybe123")]
    public void TestAuthenticateSuccess(string name, string password)
    {
        User userMoq = new User {
            Name = name,
            Password = password
        };
        Mock<UserRepository> mockRepository = new Mock<UserRepository>();
        mockRepository.Setup(r => r.Get(It.IsAny<User>())).Returns(userMoq);

        var response = new AuthController().Authenticate(userMoq);
        response.Value.Token.Should().NotBeNull();
    }


    [Theory]
    [InlineData("Luiz", "trybes2")]
    [InlineData("Mayara", "trybe1")]
    [InlineData("Rahel", "123456")]
    [InlineData("Marina", "software")]
    public void TestAuthenticateNotFoundFail(string name, string password)
    {
        User userMoq = new User {
            Name = name,
            Password = password
        };
        
        Mock<UserRepository> mockRepository = new Mock<UserRepository>();
        mockRepository.Setup(r => r.Get(It.IsAny<User>())).Returns(userMoq);

        var response = new AuthController().Authenticate(null);
        response.Result.Should().BeOfType<NotFoundObjectResult>();
    }

    
}