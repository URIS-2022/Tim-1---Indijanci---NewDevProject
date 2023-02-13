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
            CreateMap<Povrsina, PovrsinaDTO>().ReverseMap();
            CreateMap<Povrsina, PovrsinaCreateDTO>().ReverseMap();
            CreateMap<Povrsina, PovrsinaUpdateDTO>().ReverseMap();
        }
    }
}
