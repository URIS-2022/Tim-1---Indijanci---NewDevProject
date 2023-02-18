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
            CreateMap<Zalba, ZalbaDto>().ReverseMap();
            CreateMap<Zalba, ZalbaUpdateDto>().ReverseMap();
            CreateMap<Zalba, ZalbaCreateDto>().ReverseMap();
        }
    }
}
