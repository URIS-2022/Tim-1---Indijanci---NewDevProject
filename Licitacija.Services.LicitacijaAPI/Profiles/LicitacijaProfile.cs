using AutoMapper;
using Licitacija.Services.LicitacijaAPI.Entities;
using Licitacija.Services.LicitacijaAPI.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Licitacija.Services.LicitacijaAPI.DTOs.LicitacijaDTOs;

namespace Licitacija.Services.LicitacijaAPI.Profiles
{
    public class LicitacijaProfile : Profile
    {
        public LicitacijaProfile()
        {
            CreateMap<LicitacijaEntity, LicitacijaEntity>();
            CreateMap<LicitacijaEntity, LicitacijaDTO>().ReverseMap();
            CreateMap<LicitacijaEntity, LicitacijaCreateDTO>().ReverseMap();
            CreateMap<LicitacijaEntity, LicitacijaUpdateDTO>().ReverseMap();
        }
    }
}
