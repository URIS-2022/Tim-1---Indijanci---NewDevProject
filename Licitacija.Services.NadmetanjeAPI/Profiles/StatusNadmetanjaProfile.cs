using AutoMapper;
using Licitacija.Services.NadmetanjeAPI.Entities;
using Licitacija.Services.NadmetanjeAPI.Models;

namespace Licitacija.Services.NadmetanjeAPI.Profiles
{
    public class StatusNadmetanjaProfile : Profile
    {
        public StatusNadmetanjaProfile()
        {
            CreateMap<StatusNadmetanja, StatusNadmetanja>().ReverseMap();
            CreateMap<StatusNadmetanja, StatusNadmetanjaDto>().ReverseMap();
            CreateMap<StatusNadmetanja, StatusNadmetanjaCreateDto>().ReverseMap();
            CreateMap<StatusNadmetanja, StatusNadmetanjaUpdateDto>().ReverseMap();
        }
    }
}
