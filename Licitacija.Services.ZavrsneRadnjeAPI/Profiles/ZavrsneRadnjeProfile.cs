using AutoMapper;
using Licitacija.Services.ZavrsneRadnjeAPI.DTOs.ZavrsneRadnjeDto;
using Licitacija.Services.ZavrsneRadnjeAPI.Entities;

namespace Licitacija.Services.ZavrsneRadnjeAPI.Profiles
{
    public class ZavrsneRadnjeProfile : Profile
    {
        public ZavrsneRadnjeProfile()
        {
            CreateMap<ZavrsneRadnje, ZavrsneRadnje>();
            CreateMap<ZavrsneRadnje, ZavrsneRadnjeDto>().ReverseMap();
            CreateMap<ZavrsneRadnje, ZavrsneRadnjeUpdateDto>().ReverseMap();
            CreateMap<ZavrsneRadnje, ZavrsneRadnjeCreateDto>().ReverseMap();
        }
    }
}
