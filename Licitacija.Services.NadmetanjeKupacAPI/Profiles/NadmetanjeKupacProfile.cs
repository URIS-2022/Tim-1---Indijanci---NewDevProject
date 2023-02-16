using AutoMapper;
using Licitacija.Services.NadmetanjeKupacAPI.DTOs.NadmetanjeKupacDTOs;
using Licitacija.Services.NadmetanjeKupacAPI.DTOs.OvlascenoLiceDTOs;
using Licitacija.Services.NadmetanjeKupacAPI.Entities;

namespace Licitacija.Services.NadmetanjeKupacAPI.Profiles
{
    public class NadmetanjeKupacProfile : Profile
    {
        public NadmetanjeKupacProfile()
        {
            CreateMap<NadmetanjeKupacEntity, NadmetanjeKupacEntity>();
            CreateMap<NadmetanjeKupacEntity, NadmetanjeKupacDto>().ReverseMap();
            CreateMap<NadmetanjeKupacEntity, NadmetanjeKupacUpdateDto>().ReverseMap();
            CreateMap<NadmetanjeKupacEntity, NadmetanjeKupacCreateDto>().ReverseMap();
        }
    }
}
