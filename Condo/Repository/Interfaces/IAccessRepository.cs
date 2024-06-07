using Condo.Models;
using Condo.Types;

namespace Condo.Repository.Interfaces;

public interface IAccessRepository
{
    Access Add(Access access);
    Access ChangeStatus(int id, AccessStatus status);
    IEnumerable<Access> GetByCondominium(int CondominiumId);
    Access GetById(int id);
}
