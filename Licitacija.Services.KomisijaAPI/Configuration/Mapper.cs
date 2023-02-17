﻿using AutoMapper;
using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.KomisijaDtos;
using Licitacija.Services.KomisijaAPI.Models.LicnostDtos;

namespace Licitacija.Services.KomisijaAPI.Configuration
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Komisija, NovaKomisijaDto>().ReverseMap();
            CreateMap<Komisija, UpdateKomisijaDto>().ReverseMap();
            CreateMap<Komisija, GetKomisijaDto>().ReverseMap();

            CreateMap<Licnost, NovaLicnostDto>().ReverseMap();
            CreateMap<Licnost, UpdateLicnostDto>().ReverseMap();
        }
    }
}
