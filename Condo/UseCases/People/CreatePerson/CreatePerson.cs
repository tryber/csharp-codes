using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.UseCases.Interfaces;

namespace Condo.UseCases.People.CreatePerson;

public class CreatePerson : ICreatePerson
{
    protected readonly IPersonRepository _repository;
    public CreatePerson(IPersonRepository repository)
    {
        _repository = repository;
    }
    public int Execute(Person person)
    {
        int myPersonId;

        Person? existingPerson = _repository.GetByDocument(person.Document!);
        if (existingPerson != null) {
            myPersonId = existingPerson.Id;
        } else {
            Person createdPerson = _repository.Add(person);
            myPersonId = createdPerson.Id;
        }
        return myPersonId;
    }
}