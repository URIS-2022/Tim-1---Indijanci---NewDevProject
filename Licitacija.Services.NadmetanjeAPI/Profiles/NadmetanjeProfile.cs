using AutoMapper;
using Licitacija.Services.NadmetanjeAPI.Entities;
using Licitacija.Services.NadmetanjeAPI.Models;

namespace Licitacija.Services.NadmetanjeAPI.Profiles
{
    public class NadmetanjeProfile : Profile
    {
        public NadmetanjeProfile()
        {
            CreateMap<Nadmetanje, Nadmetanje>().ReverseMap();
            CreateMap<Nadmetanje, NadmetanjeDto>().ReverseMap();
            CreateMap<Nadmetanje, NadmetanjeCreateDto>().ReverseMap();
            CreateMap<Nadmetanje, NadmetanjeUpdateDto>().ReverseMap();
            CreateMap<Nadmetanje, NadmetanjeBasic>().ReverseMap();
        }
    }
}
