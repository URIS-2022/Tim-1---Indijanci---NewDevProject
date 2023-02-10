using AutoMapper;
using Licitacija.Services.PredradnjeNadmetanjaAPI.DTOs;
using Licitacija.Services.PredradnjeNadmetanjaAPI.Entities;

namespace Licitacija.Services.PredradnjeNadmetanjaAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<PredradnjeNadmetanja, PredradnjeNadmetanjaDto>().ReverseMap();
            CreateMap<PredradnjeNadmetanja, PredradnjeNadmetanjaCreateDto>().ReverseMap();
            CreateMap<PredradnjeNadmetanja, PredradnjeNadmetanjaUpdateDto>().ReverseMap();
            CreateMap<PredradnjeNadmetanja, PredradnjeBasicInfoDto>().ReverseMap();
        }
    }
}
