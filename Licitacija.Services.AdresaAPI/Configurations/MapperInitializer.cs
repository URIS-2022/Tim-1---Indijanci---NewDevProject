using AutoMapper;
using Licitacija.Services.AdresaAPI.DTOs.Adresa;
using Licitacija.Services.AdresaAPI.DTOs.Drzava;

namespace Licitacija.Services.AdresaAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Drzava, DrzavaDTO>().ReverseMap();
            CreateMap<Drzava, DrzavaCreateDTO>().ReverseMap();
            CreateMap<Drzava, DrzavaUpdateDTO>().ReverseMap();

            CreateMap<Adresa, AdresaDTO>().ReverseMap();
            CreateMap<Adresa, AdresaCreateDTO>().ReverseMap();
            CreateMap<Adresa, AdresaUpdateDTO>().ReverseMap();
        }
    }
}
