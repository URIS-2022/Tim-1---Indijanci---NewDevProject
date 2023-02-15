using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.ParcelaDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.ParcelaAPI.Profiles
{
    public class ParcelaProfile : Profile
    {
        public ParcelaProfile()
        {
            CreateMap<Parcela, Parcela>();
            CreateMap<Parcela, ParcelaDTO>().ReverseMap();
            CreateMap<Parcela, ParcelaCreateDTO>().ReverseMap();
            CreateMap<Parcela, ParcelaUpdateDTO>().ReverseMap();
        }
    }
}
