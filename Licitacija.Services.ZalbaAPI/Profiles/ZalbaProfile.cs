using AutoMapper;
using Licitacija.Services.ZalbaAPI.DTOs.TipZalbeDTOs;
using Licitacija.Services.ZalbaAPI.DTOs.ZalbaDTOs;
using Licitacija.Services.ZalbaAPI.Entities;

namespace Licitacija.Services.ZalbaAPI.Profiles
{
    public class ZalbaProfile : Profile
    {
        public ZalbaProfile()
        {
            CreateMap<Zalba, Zalba>();
            CreateMap<Zalba, ZalbaDTO>().ReverseMap();
            CreateMap<Zalba, ZalbaUpdateDTO>().ReverseMap();
            CreateMap<Zalba, ZalbaCreateDTO>().ReverseMap();
        }
    }
}
