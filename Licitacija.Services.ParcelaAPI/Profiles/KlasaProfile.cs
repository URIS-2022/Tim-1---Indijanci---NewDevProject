using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.KlasaDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.ParcelaAPI.Profiles
{
    public class KlasaProfile : Profile
    {
        public KlasaProfile()
        {
            CreateMap<Klasa, Klasa>();
            CreateMap<Klasa, KlasaDTO>().ReverseMap();
            CreateMap<Klasa, KlasaCreateDTO>().ReverseMap();
            CreateMap<Klasa, KlasaUpdateDTO>().ReverseMap();
        }
    }
}
