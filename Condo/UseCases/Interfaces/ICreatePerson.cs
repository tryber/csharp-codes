
using Condo.Models;
namespace Condo.UseCases.Interfaces;
public interface ICreatePerson
{
    int Execute(Person person);
}