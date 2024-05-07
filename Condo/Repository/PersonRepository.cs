using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.Context.Interfaces;

namespace Condo.Repository;

public class PersonRepository : IPersonRepository
{
    protected readonly IDatabaseContext _dbContext;
    public PersonRepository(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Person Add(Person person)
    {
        _dbContext.Person.Add(person);
        _dbContext.SaveChanges();
        return person;
    }

    public Person? GetByDocument(string Document)
    {
        Person? existingPerson = _dbContext.Person.Where(p => p.Document == Document).FirstOrDefault();
        return existingPerson;
    }

    public Person GetById(int id)
    {
        Person? person = _dbContext.Person.Find(id);
        if (person == null) throw new Exception("Person not found");
        return person;
    }
}