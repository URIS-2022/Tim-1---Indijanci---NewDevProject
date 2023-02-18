using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.OdvodnjavanjeDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.ParcelaAPI.Profiles
{
    public class OdvodnjavanjeProfile : Profile
    {
        public OdvodnjavanjeProfile()
        {
            CreateMap<Odvodnjavanje, Odvodnjavanje>();
            CreateMap<Odvodnjavanje, OdvodnjavanjeDto>().ReverseMap();
            CreateMap<Odvodnjavanje, OdvodnjavanjeCreateDto>().ReverseMap();
            CreateMap<Odvodnjavanje, OdvodnjavanjeUpdateDto>().ReverseMap();
        }
    }
}
