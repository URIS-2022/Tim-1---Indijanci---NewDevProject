using AutoMapper;
using Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs;
using Licitacija.Services.PredradnjeNadmetanjaAPI.Entities;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<PredradnjeNadmetanja, PredradnjeNadmetanjaDTO>().ReverseMap();
            CreateMap<PredradnjeNadmetanja, PredradnjeNadmetanjaCreateDTO>().ReverseMap();
            CreateMap<PredradnjeNadmetanja, PredradnjeNadmetanjaUpdateDTO>().ReverseMap();
        }
    }
}
