using AutoMapper;
using Licitacija.Services.NadmetanjeAPI.Entities;
using Licitacija.Services.NadmetanjeAPI.Models;

namespace Licitacija.Services.NadmetanjeAPI.Profiles
{
    public class JavnoProfile : Profile
    {
        public JavnoProfile()
        {
            CreateMap<Javno, Javno>().ReverseMap();
            CreateMap<Javno, JavnoDto>().ReverseMap();
            CreateMap<Javno, JavnoCreateDto>().ReverseMap();
            CreateMap<Javno, JavnoUpdateDto>().ReverseMap();
        }
    }
}
