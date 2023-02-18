using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.PovrsinaDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.ParcelaAPI.Profiles
{
    public class PovrsinaProfile : Profile
    {
        public PovrsinaProfile()
        {
            CreateMap<Povrsina, Povrsina>();
            CreateMap<Povrsina, PovrsinaDto>().ReverseMap();
            CreateMap<Povrsina, PovrsinaCreateDto>().ReverseMap();
            CreateMap<Povrsina, PovrsinaUpdateDto>().ReverseMap();
        }
    }
}
