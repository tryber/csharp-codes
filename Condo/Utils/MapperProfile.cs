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
    }
}