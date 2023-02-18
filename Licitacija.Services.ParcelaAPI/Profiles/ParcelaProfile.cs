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
            CreateMap<Parcela, ParcelaDto>().ReverseMap();
            CreateMap<Parcela, ParcelaCreateDto>().ReverseMap();
            CreateMap<Parcela, ParcelaUpdateDto>().ReverseMap();
        }
    }
}
