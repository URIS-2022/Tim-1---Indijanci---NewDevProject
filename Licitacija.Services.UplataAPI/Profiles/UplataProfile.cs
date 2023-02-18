using AutoMapper;
using Licitacija.Services.UplataAPI.Entities;
using Licitacija.Services.UplataAPI.Models;

namespace Licitacija.Services.UplataAPI.Profiles
{
    public class UplataProfile : Profile
    {
        public UplataProfile()
        {
            CreateMap<Uplata, Uplata>();
            CreateMap<Uplata, UplataDto>().ReverseMap();
            CreateMap<Uplata, UplataCreateDto>().ReverseMap();
            CreateMap<Uplata, UplataUpdateDto>().ReverseMap();
            CreateMap<Uplata, UplataBasicDto>().ReverseMap();
        }
    }
}
