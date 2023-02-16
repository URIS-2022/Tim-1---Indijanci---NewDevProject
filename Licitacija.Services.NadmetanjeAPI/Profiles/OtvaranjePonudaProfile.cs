using AutoMapper;
using Licitacija.Services.NadmetanjeAPI.Entities;
using Licitacija.Services.NadmetanjeAPI.Models;

namespace Licitacija.Services.NadmetanjeAPI.Profiles
{
    public class OtvaranjePonudaProfile : Profile
    {
        public OtvaranjePonudaProfile()
        {
            CreateMap<OtvaranjePonuda, OtvaranjePonuda>().ReverseMap();
            CreateMap<OtvaranjePonuda, OtvaranjePonudaDto>().ReverseMap();
            CreateMap<OtvaranjePonuda, OtvaranjePonudaCreateDto>().ReverseMap();
            CreateMap<OtvaranjePonuda, OtvaranjePonudaUpdateDto>().ReverseMap();
            CreateMap<OtvaranjePonuda, OtvaranjePonudaBasic>().ReverseMap();
        }
    }
}
