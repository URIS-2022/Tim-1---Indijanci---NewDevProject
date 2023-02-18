using AutoMapper;
using Licitacija.Services.ProgramLicitacijeAPI.Entities;
using Licitacija.Services.ProgramLicitacijeAPI.Models.KreiranjeProgramaLicitacijeDtos;

namespace Licitacija.Services.ProgramLicitacijeAPI.Configurations
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<KreiranjeProgramaLicitacije, NoviProgramLicitacijeDto>().ReverseMap();
            CreateMap<KreiranjeProgramaLicitacije, UpdateProgramLicitacijeDto>().ReverseMap();
            CreateMap<KreiranjeProgramaLicitacije, GetKreiranjeProgramaLicitacijeDto>().ReverseMap();
        }
    }
}
