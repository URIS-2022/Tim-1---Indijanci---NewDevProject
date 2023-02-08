using AutoMapper;
using Licitacija.Services.UplataAPI.Entities;
using Licitacija.Services.UplataAPI.Models;

namespace Licitacija.Services.UplataAPI.Profiles
{
    public class KursProfile : Profile
    {
        public KursProfile()
        {
            CreateMap<Kurs, Kurs>();
            CreateMap<Kurs, KursDTO>().ReverseMap();
            CreateMap<Kurs, KursCreateDTO>().ReverseMap();
            CreateMap<Kurs, KursUpdateDTO>().ReverseMap();
        }
    }
}
