using AutoMapper;
using projeto_akross_2.Data.Dtos;
using projeto_akross_2.Models;

namespace projeto_akross_2.Profiles;

public class ColaboradorProfile : Profile
{
    public ColaboradorProfile()
    {
        CreateMap<CreateColaboradorDto, Colaborador>();
        CreateMap<UpdateColaboradorDto, Colaborador>();
        CreateMap<Colaborador, UpdateColaboradorDto>();
        CreateMap<Colaborador, ReadColaboradorDto>()
            .ForMember(colaboradorDto => colaboradorDto.Squad, opt => opt.MapFrom(colaborador => colaborador.Squad));
    }
}
