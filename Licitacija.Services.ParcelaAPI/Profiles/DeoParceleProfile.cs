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
            CreateMap<DeoParcele, DeoParceleDTO>().ReverseMap();
            CreateMap<DeoParcele, DeoParceleCreateDTO>().ReverseMap();
            CreateMap<DeoParcele, DeoParceleUpdateDTO>().ReverseMap();
        }
    }
}
