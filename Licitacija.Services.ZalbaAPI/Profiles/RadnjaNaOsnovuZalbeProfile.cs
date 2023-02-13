using AutoMapper;
using Licitacija.Services.ZalbaAPI.DTOs.RadnjaNaOsnovuZalbeDTOs;
using Licitacija.Services.ZalbaAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.ZalbaAPI.Profiles
{
    public class RadnjaNaOsnovuZalbeProfile : Profile
    {
        public RadnjaNaOsnovuZalbeProfile()
        {
            CreateMap<RadnjaNaOsnovuZalbe, RadnjaNaOsnovuZalbe>();
            CreateMap<RadnjaNaOsnovuZalbe, RadnjaNaOsnovuZalbeDTO>().ReverseMap();
            CreateMap<RadnjaNaOsnovuZalbe, RadnjaNaOsnovuZalbeCreateDTO>().ReverseMap();
            CreateMap<RadnjaNaOsnovuZalbe, RadnjaNaOsnovuZalbeUpdateDTO>().ReverseMap();
        }

    }
}
