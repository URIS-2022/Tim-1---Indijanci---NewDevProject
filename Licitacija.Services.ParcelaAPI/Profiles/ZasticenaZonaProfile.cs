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
            CreateMap<ZasticenaZona, ZasticenaZonaDTO>().ReverseMap();
            CreateMap<ZasticenaZona, ZasticenaZonaCreateDTO>().ReverseMap();
            CreateMap<ZasticenaZona, ZasticenaZonaUpdateDTO>().ReverseMap();
        }
    }
}
