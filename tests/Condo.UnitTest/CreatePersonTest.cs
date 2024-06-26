namespace Condo.UnitTest;
using Moq;
using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.UseCases.Interfaces;
using Condo.UseCases.People.CreatePerson;


public class CreatePersonTest
{
    private Mock<IPersonRepository> _mockPersonRepository;

    public CreatePersonTest()
    {
        _mockPersonRepository = new Mock<IPersonRepository>();
    }


    [Trait("Category", "Test Create Person Use Case - Create new person")]
    [Theory(DisplayName = "Test Create Person Use Case - Create new person")]
    [InlineData(2)]
    public void Test_CreatePersonTest(int expectedPersonId)
    {
        Person personMoq = new Person {
            Id = expectedPersonId,
            Name = "Rebeca",
            Document = "444444444"
        };

        Person newPerson = new Person {
            Name = "Rebeca",
            Document = "444444444"
        };

        _mockPersonRepository.Setup(r => r.GetByDocument(It.IsAny<string>()))
                             .Returns(default(Person));

        _mockPersonRepository.Setup(r => r.Add(It.IsAny<Person>()))
                             .Returns(personMoq);
            
        var createPersonUseCase = new CreatePerson(_mockPersonRepository.Object);
        var result = createPersonUseCase.Execute(newPerson);

        Assert.Equal(expectedPersonId, result);
    }

    [Trait("Category", "Test Create Person Use Case - Return existing person")]
    [Theory(DisplayName = "Test Create Person Use Case - Return existing person")]
    [InlineData(2)]
    public void Test_CreatePersonTest_ExistingPerson(int expectedPersonId)
    {
        Person personMoq = new Person {
            Id = expectedPersonId,
            Name = "Rebeca",
            Document = "444444444"
        };

        Person newPerson = new Person {
            Name = "Rebeca",
            Document = "444444444"
        };

        _mockPersonRepository.Setup(r => r.GetByDocument(It.IsAny<string>()))
                             .Returns(personMoq);
        
        var createPersonUseCase = new CreatePerson(_mockPersonRepository.Object);
        var result = createPersonUseCase.Execute(newPerson);

        Assert.Equal(expectedPersonId, result);
    }
}