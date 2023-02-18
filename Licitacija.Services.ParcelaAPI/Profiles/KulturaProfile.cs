using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.KulturaDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.ParcelaAPI.Profiles
{
    public class KulturaProfile : Profile
    {
        public KulturaProfile()
        {
            CreateMap<Kultura, Kultura>();
            CreateMap<Kultura, KulturaDto>().ReverseMap();
            CreateMap<Kultura, KulturaCreateDto>().ReverseMap();
            CreateMap<Kultura, KulturaUpdateDto>().ReverseMap();
        }
    }
}
