namespace Condo.Utils;

using AutoMapper;
using Condo.Models;
using Condo.DTOs;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Unity, UnityResponseDTO>();
        CreateMap<Condominium, CondominiumResponseDTO>();
        CreateMap<Person, PersonResponseDTO>();
        
        CreateMap<Resident, ResidentResponseDTO>()
            .ForPath(dest => dest.Condominium!.Id, map => map.MapFrom(r => r.Unity!.Condominium!.Id))
            .ForPath(dest => dest.Condominium!.Name, map => map.MapFrom(r => r.Unity!.Condominium!.Name))
            .ForPath(dest => dest.Condominium!.Type, map => map.MapFrom(r => r.Unity!.Condominium!.Type));
        
        CreateMap<User, UserCreatedResponseDTO>();

        CreateMap<Access, AccessResponseDTO>()
            .ForPath(dest => dest.Condominium!.Id, map => map.MapFrom(r => r.Unity!.Condominium!.Id))
            .ForPath(dest => dest.Condominium!.Name, map => map.MapFrom(r => r.Unity!.Condominium!.Name))
            .ForPath(dest => dest.Condominium!.Type, map => map.MapFrom(r => r.Unity!.Condominium!.Type));
    }
}