using Condo.Models;

namespace Condo.Repository.Interfaces;

public interface IUnityRepository
{
    IEnumerable<Unity> Get();
    Unity GetById(int id);
    Unity Add(Unity unity);
    Unity Update(int id, Unity unity);
    void Delete(int id);
}