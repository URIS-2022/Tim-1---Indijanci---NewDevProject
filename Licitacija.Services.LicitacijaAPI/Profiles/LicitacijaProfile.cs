using AutoMapper;
using Licitacija.Services.LicitacijaAPI.Entities;
using Licitacija.Services.LicitacijaAPI.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Licitacija.Services.LicitacijaAPI.DTOs.LicitacijaDTOs;
using Licitacija.Services.LicitacijaAPI.DTOs.ExchangeDTOs;

namespace Licitacija.Services.LicitacijaAPI.Profiles
{
    public class LicitacijaProfile : Profile
    {
        public LicitacijaProfile()
        {
            CreateMap<LicitacijaEntity, LicitacijaEntity>();
            CreateMap<LicitacijaEntity, LicitacijaDto>().ReverseMap();
            CreateMap<LicitacijaEntity, LicitacijaCreateDto>().ReverseMap();
            CreateMap<LicitacijaEntity, LicitacijaUpdateDto>().ReverseMap();
            CreateMap<LicitacijaEntity, LicitacijaBasicInfoDto>();
        }
    }
}
