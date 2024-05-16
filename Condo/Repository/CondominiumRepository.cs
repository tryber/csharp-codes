using Condo.Context.Interfaces;
using Condo.Models;
using Condo.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Condo.Repository;

public class CondominiumRepository : ICondominiumRepository
{
    protected readonly IDatabaseContext _context;

    public CondominiumRepository(IDatabaseContext context)
    {
        _context = context;
    }
    public Condominium Add(Condominium condominium)
    {
        _context.Condominiums.Add(condominium);
        _context.SaveChanges();
        return condominium;
    }



    public IEnumerable<Condominium> Get()
    {
        return _context.Condominiums.Include(c => c.Units);
    }

    public Condominium GetById(int Id)
    {
        Condominium? existingCondominium = _context.Condominiums
                                                    .Include(c => c.Units)
                                                    .FirstOrDefault(c => c.Id == Id);
        if (existingCondominium == null) throw new Exception("Condominium not found");
        return existingCondominium;
    }

    public Condominium Update(int Id, Condominium condominium)
    {
        Condominium? existingCondominium = _context.Condominiums.Find(Id);
        if (existingCondominium == null) throw new Exception("Condominium not found");
        
        condominium.Id = Id;
        _context.Entry(existingCondominium).CurrentValues.SetValues(condominium);
        _context.Condominiums.Update(existingCondominium);
        _context.SaveChanges();
        return existingCondominium;

    }

    public void Delete(int Id)
    {
        Condominium? existingCondominium = _context.Condominiums.Find(Id);
        if (existingCondominium == null) throw new Exception("Condominium not found");

        _context.Condominiums.Remove(existingCondominium);
        _context.SaveChanges();
    }
}