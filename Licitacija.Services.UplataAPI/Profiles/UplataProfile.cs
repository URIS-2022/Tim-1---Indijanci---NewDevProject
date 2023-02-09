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
            CreateMap<Uplata, UplataDTO>().ReverseMap();
            CreateMap<Uplata, UplataCreateDTO>().ReverseMap();
            CreateMap<Uplata, UplataUpdateDTO>().ReverseMap();
        }
    }
}
