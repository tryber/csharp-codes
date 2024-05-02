using Condo.Context.Interfaces;
using Condo.Models;
using Condo.Repository.Interfaces;

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
        return _context.Condominiums;
    }
}