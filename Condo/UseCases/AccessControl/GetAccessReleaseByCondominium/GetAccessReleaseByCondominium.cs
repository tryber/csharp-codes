using AutoMapper;
using Condo.DTOs;
using Condo.Models;
using Condo.Repository.Interfaces;
using Condo.UseCases.Interfaces;

namespace Condo.UseCases.AccessControl.GetAccessReleaseByCondominium;

public class GetAccessReleaseByCondominium : IGetAccessReleaseByCondominium
{
      protected readonly IAccessRepository _repository;
    protected readonly IMapper _mapper;
    public GetAccessReleaseByCondominium(IAccessRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public IEnumerable<AccessResponseDTO> Execute(int CondominiumId)
    {
        return _mapper.Map<IEnumerable<Access>, IEnumerable<AccessResponseDTO>>(_repository.GetByCondominium(CondominiumId));
    }
}