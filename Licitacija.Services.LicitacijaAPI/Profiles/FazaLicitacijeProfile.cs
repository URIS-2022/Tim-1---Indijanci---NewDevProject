using AutoMapper;
using Licitacija.Services.LicitacijaAPI.Entities;
using Licitacija.Services.LicitacijaAPI.DTOs;
using Licitacija.Services.LicitacijaAPI.DTOs.FazaLicitacijeDTOs;
using Licitacija.Services.LicitacijaAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.LicitacijaAPI.Profiles
{
    public class FazaLicitacijeProfile : Profile
    {
        public FazaLicitacijeProfile()
        {
            CreateMap<FazaLicitacije, FazaLicitacije>();
            CreateMap<FazaLicitacije, FazaLicitacijeDto>().ReverseMap();
            CreateMap<FazaLicitacije, FazaLicitacijeCreateDto>().ReverseMap();
            CreateMap<FazaLicitacije, FazaLicitacijeUpdateDto>().ReverseMap();
            CreateMap<FazaLicitacije, FazaLicitacijeBasicInfoDto>();
        }
       

    }
}
