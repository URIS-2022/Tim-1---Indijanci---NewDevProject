using AutoMapper;
using Licitacija.Services.NadmetanjeKupacAPI.DTOs.OvlascenoLiceDTOs;
using Licitacija.Services.NadmetanjeKupacAPI.Entities;

namespace Licitacija.Services.NadmetanjeKupacAPI.Profiles
{
    public class OvlascenoLiceProfile : Profile
    {
        public OvlascenoLiceProfile()
        {
            CreateMap<OvlascenoLice, OvlascenoLice>();
            CreateMap<OvlascenoLice, OvlascenoLiceDto>().ReverseMap();
            CreateMap<OvlascenoLice, OvlascenoLiceUpdateDto>().ReverseMap();
            CreateMap<OvlascenoLice, OvlascenoLiceCreateDto>().ReverseMap();
        }
    }
}
