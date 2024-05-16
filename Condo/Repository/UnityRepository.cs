using Condo.Context.Interfaces;
using Condo.Models;
using Condo.Repository.Interfaces;

namespace Condo.Repository;

public class UnityRepository : IUnityRepository
{
    protected readonly IDatabaseContext _context;

    public UnityRepository(IDatabaseContext context)
    {
        _context = context;
    }
    public IEnumerable<Unity> Get()
    {
        return _context.Unities;
    }
    public Unity GetById(int id)
    {
        Unity? existingUnity = _context.Unities.Find(id);
        if (existingUnity == null) throw new Exception("Unity not found");
        return existingUnity;
    }
    public Unity Add(Unity unity)
    {   
        _context.Unities.Add(unity);
        _context.SaveChanges();
        return unity;
    }

    public Unity Update(int id, Unity unity)
    {
        Unity? existingUnity = _context.Unities.Find(id);
        if (existingUnity == null) throw new Exception("Unity not found");
        unity.Id = id;
        _context.Entry(existingUnity).CurrentValues.SetValues(unity);
        _context.Unities.Update(existingUnity);
        _context.SaveChanges();
        return existingUnity;
    }
    public void Delete(int id)
    {
          Unity? existingUnity = _context.Unities.Find(id);
        if (existingUnity == null) throw new Exception("Unity not found");
        _context.Unities.Remove(existingUnity);
        _context.SaveChanges();
    }
}