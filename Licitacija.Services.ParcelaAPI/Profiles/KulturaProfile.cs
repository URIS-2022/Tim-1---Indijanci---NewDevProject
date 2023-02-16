﻿using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.KulturaDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.ParcelaAPI.Profiles
{
    public class KulturaProfile : Profile
    {
        public KulturaProfile()
        {
            CreateMap<Kultura, Kultura>();
            CreateMap<Kultura, KulturaDTO>().ReverseMap();
            CreateMap<Kultura, KulturaCreateDTO>().ReverseMap();
            CreateMap<Kultura, KulturaUpdateDTO>().ReverseMap();
        }
    }
}
