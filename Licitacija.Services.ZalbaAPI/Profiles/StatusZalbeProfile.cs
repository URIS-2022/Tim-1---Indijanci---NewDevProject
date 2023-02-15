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
            CreateMap<StatusZalbe, StatusZalbeDTO>().ReverseMap();
            CreateMap<StatusZalbe, StatusZalbeUpdateDTO>().ReverseMap();
            CreateMap<StatusZalbe, StatusZalbeCreateDTO>().ReverseMap();
        }
    }
}
