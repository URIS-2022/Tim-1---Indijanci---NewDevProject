using AutoMapper;
using Licitacija.Services.KupacAPI.DTOs.KontaktOsobaDTOs;
using Licitacija.Services.KupacAPI.DTOs.PrioritetDTOs;
using Licitacija.Services.KupacAPI.Entities;

namespace Licitacija.Services.KupacAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Prioritet, PrioritetDTO>().ReverseMap();
            CreateMap<Prioritet, PrioritetCreateDTO>().ReverseMap();
            CreateMap<Prioritet, PrioritetUpdateDTO>().ReverseMap();

            CreateMap<KontaktOsoba, KontaktOsobaDTO>().ReverseMap();
            CreateMap<KontaktOsoba, KontaktOsobaCreateDTO>().ReverseMap();
            CreateMap<KontaktOsoba, KontaktOsobaUpdateDTO>().ReverseMap();
        }
    }
}
