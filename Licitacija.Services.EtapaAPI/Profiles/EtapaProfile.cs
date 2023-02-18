using AutoMapper;
using Licitacija.Services.EtapaAPI.DTOs.EtapaDTOs;
using Licitacija.Services.EtapaAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.EtapaAPI.Entities;

namespace Licitacija.Services.EtapaAPI.Profiles
{
    public class EtapaProfile : Profile
    {
        public EtapaProfile() 
        {
            CreateMap<Etapa, Etapa>();
            CreateMap<Etapa, EtapaDto>().ReverseMap();
            CreateMap<Etapa, EtapaCreateDto>().ReverseMap();
            CreateMap<Etapa, EtapaUpdateDto>().ReverseMap();
            CreateMap<Etapa, EtapaBasicInfoDto>();
        }
    }
}
