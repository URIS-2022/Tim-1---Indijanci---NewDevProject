﻿using AutoMapper;
using Licitacija.Services.LicitacijaAPI.Entities;
using Licitacija.Services.LicitacijaAPI.DTOs;
using Licitacija.Services.LicitacijaAPI.DTOs.FazaLicitacijeDTOs;

namespace Licitacija.Services.LicitacijaAPI.Profiles
{
    public class FazaLicitacijeProfile : Profile
    {
        public FazaLicitacijeProfile()
        {
            CreateMap<FazaLicitacije, FazaLicitacije>();
            CreateMap<FazaLicitacije, FazaLicitacijeDTO>().ReverseMap();
            CreateMap<FazaLicitacije, FazaLicitacijeCreateDTO>().ReverseMap();
            CreateMap<FazaLicitacije, FazaLicitacijeUpdateDTO>().ReverseMap();
        }
       

    }
}
