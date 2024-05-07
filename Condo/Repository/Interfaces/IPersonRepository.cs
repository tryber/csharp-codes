using Condo.Models;

namespace Condo.Repository.Interfaces;

public interface IPersonRepository
{
    Person GetById(int id);
    Person? GetByDocument(string Document);
    Person Add(Person person);
}