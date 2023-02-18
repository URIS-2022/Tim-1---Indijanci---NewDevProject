using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.ZasticenaZonaDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.ParcelaAPI.Profiles
{
    public class ZasticenaZonaProfile : Profile
    {
        public ZasticenaZonaProfile()
        {
            CreateMap<ZasticenaZona, ZasticenaZona>();
            CreateMap<ZasticenaZona, ZasticenaZonaDto>().ReverseMap();
            CreateMap<ZasticenaZona, ZasticenaZonaCreateDto>().ReverseMap();
            CreateMap<ZasticenaZona, ZasticenaZonaUpdateDto>().ReverseMap();
        }
    }
}
