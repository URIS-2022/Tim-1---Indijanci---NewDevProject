using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.ObradivostDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.ParcelaAPI.Profiles
{
    public class ObradivostProfile : Profile
    {
        public ObradivostProfile()
        {
            CreateMap<Obradivost, Obradivost>();
            CreateMap<Obradivost, ObradivostDTO>().ReverseMap();
            CreateMap<Obradivost, ObradivostCreateDTO>().ReverseMap();
            CreateMap<Obradivost, ObradivostUpdateDTO>().ReverseMap();
        }
    }
}
