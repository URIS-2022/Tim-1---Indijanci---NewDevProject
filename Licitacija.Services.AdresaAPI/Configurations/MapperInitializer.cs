using AutoMapper;
using Licitacija.Services.AdresaAPI.DTOs.Adresa;
using Licitacija.Services.AdresaAPI.DTOs.Drzava;
using Licitacija.Services.AdresaAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.AdresaAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Drzava, DrzavaDto>().ReverseMap();
            CreateMap<Drzava, DrzavaCreateDto>().ReverseMap();
            CreateMap<Drzava, DrzavaUpdateDto>().ReverseMap();

            CreateMap<Adresa, AdresaDto>().ReverseMap();
            CreateMap<Adresa, AdresaCreateDto>().ReverseMap();
            CreateMap<Adresa, AdresaUpdateDto>().ReverseMap();

            CreateMap<Adresa, AdresaExchangeDto>().ReverseMap();
        }
    }
}
