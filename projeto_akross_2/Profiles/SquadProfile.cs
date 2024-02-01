using AutoMapper;
using projeto_akross_2.Data.Dtos;
using projeto_akross_2.Models;

namespace projeto_akross_2.Profiles;

public class SquadProfile : Profile
{
    public SquadProfile()
    {
        CreateMap<CreateSquadDto, Squad>();
        CreateMap<UpdateSquadDto, Squad>();
        CreateMap<Squad, UpdateSquadDto>();
        CreateMap<Squad, ReadSquadDto>();
    }
}
