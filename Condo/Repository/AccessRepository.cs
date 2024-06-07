using System.Linq.Expressions;
using Condo.Context.Interfaces;
using Condo.Exceptions;
using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.Types;
using Microsoft.EntityFrameworkCore;

namespace Condo.Repository;

public class AccessRepository : IAccessRepository
{
    protected readonly IDatabaseContext _dbContext;

    public AccessRepository(IDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Access Add(Access access)
    {
        access.Status = AccessStatus.Pending;
        _dbContext.AccessControl.Add(access);
        _dbContext.SaveChanges();
        return _dbContext.AccessControl
                         .Include(a => a.Person)
                         .Include(a => a.Unity)
                         .ThenInclude(u => u!.Condominium)
                         .FirstOrDefault(a => a.Id == access.Id)!;
    }

    public Access ChangeStatus(int id, AccessStatus status)
    {
        Access? access = _dbContext.AccessControl.Find(id);
        if (access == null) throw new NotFoundException("Access not found");

        access.Status = status;
        _dbContext.AccessControl.Update(access);
        _dbContext.SaveChanges();

        return _dbContext.AccessControl
                         .Include(a => a.Person)
                         .Include(a => a.Unity)
                         .ThenInclude(u => u!.Condominium)
                         .FirstOrDefault(a => a.Id == id)!;
    }

    public IEnumerable<Access> GetByCondominium(int CondominiumId)
    {
         return _dbContext.AccessControl
                         .Include(a => a.Person)
                         .Include(a => a.Unity)
                         .ThenInclude(u => u!.Condominium)
                         .Where(a => a.Unity!.CondominiumId == CondominiumId);
    }

    public Access GetById(int id)
    {
         Access? access = _dbContext.AccessControl
                         .Include(a => a.Person)
                         .Include(a => a.Unity)
                         .ThenInclude(u => u!.Condominium)
                         .FirstOrDefault(a => a.Id == id)!;

        if (access == null) throw new NotFoundException("Access not found");
        return access;
    }
}