using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.DeoParceleDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.ParcelaAPI.Profiles
{
    public class DeoParceleProfile : Profile
    {
        public DeoParceleProfile()
        {
            CreateMap<DeoParcele, DeoParcele>();
            CreateMap<DeoParcele, DeoParceleDto>().ReverseMap();
            CreateMap<DeoParcele, DeoParceleCreateDto>().ReverseMap();
            CreateMap<DeoParcele, DeoParceleUpdateDto>().ReverseMap();
        }
    }
}
