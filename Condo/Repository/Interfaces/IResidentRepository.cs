namespace Condo.Repository.Interfaces;
using Condo.Models;

public interface IResidentRepository
{
    IEnumerable<Resident> GetByCondominium(int CondominiumId);
    IEnumerable<Resident> GetByUnit(int UnityId);
    Resident GetById(int id);
    Resident Add(Resident resident);
}