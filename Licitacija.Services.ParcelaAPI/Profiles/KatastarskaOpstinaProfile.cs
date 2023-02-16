using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.ParcelaAPI.DTOs.KatastarskaOpstinaDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.ParcelaAPI.Profiles
{
    public class KatastarskaOpstinaProfile : Profile
    {
        public KatastarskaOpstinaProfile()
        {
            CreateMap<KatastarskaOpstina, KatastarskaOpstina>();
            CreateMap<KatastarskaOpstina, KatastarskaOpstinaDTO>().ReverseMap();
            CreateMap<KatastarskaOpstina, KatastarskaOpstinaCreateDTO>().ReverseMap();
            CreateMap<KatastarskaOpstina, KatastarskaOpstinaUpdateDTO>().ReverseMap();
            CreateMap<KatastarskaOpstina, KatastarskaOpstinaBasicInfoDTO>();

        }
    }
}
