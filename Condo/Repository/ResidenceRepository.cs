using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.Context.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Condo.Repository;

public class ResidentRepository : IResidentRepository
{

    protected readonly IDatabaseContext _dbContext;

    public ResidentRepository(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Resident Add(Resident resident)
    {
        _dbContext.Residents.Add(resident);
        _dbContext.SaveChanges();
        return _dbContext.Residents
                         .Include(r => r.Person)
                         .Include(r => r.Unity)
                         .ThenInclude(u => u.Condominium)
                         .FirstOrDefault(r => r.Id == resident.Id)!;
    }

    public IEnumerable<Resident> GetByCondominium(int CondominiumId)
    {
        return _dbContext.Residents
                         .Include(r => r.Person)
                         .Include(r => r.Unity)
                         .ThenInclude(u => u.Condominium)
                         .Where(r => r.Unity!.CondominiumId == CondominiumId);
    }

    public IEnumerable<Resident> GetByUnit(int UnityId)
    {
         return _dbContext.Residents
                         .Include(r => r.Person)
                         .Include(r => r.Unity)
                         .ThenInclude(u => u.Condominium)
                         .Where(r => r.UnityId == UnityId);
    }

    public Resident GetById(int id)
    {
        Resident? existingResident = _dbContext.Residents
                         .Include(r => r.Person)
                         .Include(r => r.Unity)
                         .ThenInclude(u => u.Condominium)
                         .FirstOrDefault(r => r.Id == id);
        if (existingResident == null) throw new Exception("Resident not found");
        return existingResident;
    }

  
}