using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.OblikSvojineDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.ParcelaAPI.Profiles
{
    public class OblikSvojineProfile : Profile
    {
        public OblikSvojineProfile()
        {
            CreateMap<OblikSvojine, OblikSvojine>();
            CreateMap<OblikSvojine, OblikSvojineDto>().ReverseMap();
            CreateMap<OblikSvojine, OblikSvojineCreateDto>().ReverseMap();
            CreateMap<OblikSvojine, OblikSvojineUpdateDto>().ReverseMap();
        }
    }
}
