using AutoMapper;
using Licitacija.Services.ZalbaAPI.DTOs.RadnjaNaOsnovuZalbeDTOs;
using Licitacija.Services.ZalbaAPI.DTOs.TipZalbeDTOs;
using Licitacija.Services.ZalbaAPI.Entities;

namespace Licitacija.Services.ZalbaAPI.Profiles
{
    public class TipZalbeProfile : Profile
    {
        public TipZalbeProfile()
        {
            CreateMap<TipZalbe, TipZalbe>();
            CreateMap<TipZalbe, TipZalbeDTO>().ReverseMap();
            CreateMap<TipZalbe, TipZalbeUpdateDTO>().ReverseMap();
            CreateMap<TipZalbe, TipZalbeCreateDTO>().ReverseMap();
        }
    }
}
