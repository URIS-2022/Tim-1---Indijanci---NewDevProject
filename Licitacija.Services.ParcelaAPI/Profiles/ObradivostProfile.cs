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
            CreateMap<Obradivost, ObradivostDto>().ReverseMap();
            CreateMap<Obradivost, ObradivostCreateDto>().ReverseMap();
            CreateMap<Obradivost, ObradivostUpdateDto>().ReverseMap();
        }
    }
}
