using AutoMapper;
using Licitacija.Services.ZalbaAPI.DTOs.RadnjaNaOsnovuZalbeDTOs;
using Licitacija.Services.ZalbaAPI.DTOs.StatusZalbeDTOs;
using Licitacija.Services.ZalbaAPI.Entities;

namespace Licitacija.Services.ZalbaAPI.Profiles
{
    public class StatusZalbeProfile : Profile
    {
        public StatusZalbeProfile()
        {
            CreateMap<StatusZalbe, StatusZalbe>();
            CreateMap<StatusZalbe, StatusZalbeDto>().ReverseMap();
            CreateMap<StatusZalbe, StatusZalbeUpdateDto>().ReverseMap();
            CreateMap<StatusZalbe, StatusZalbeCreateDto>().ReverseMap();
        }
    }
}
