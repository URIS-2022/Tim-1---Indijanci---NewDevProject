using AutoMapper;
using Licitacija.Services.KupacAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.KupacAPI.DTOs.FizickoLiceDTOs;
using Licitacija.Services.KupacAPI.DTOs.KontaktOsobaDTOs;
using Licitacija.Services.KupacAPI.DTOs.KupacDTO;
using Licitacija.Services.KupacAPI.DTOs.PravnoLiceDTOs;
using Licitacija.Services.KupacAPI.DTOs.PrioritetDTOs;
using Licitacija.Services.KupacAPI.Entities;

namespace Licitacija.Services.KupacAPI.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            //Mapiranja za prioritet
            CreateMap<Prioritet, PrioritetDto>().ReverseMap();
            CreateMap<Prioritet, PrioritetCreateDto>().ReverseMap();
            CreateMap<Prioritet, PrioritetUpdateDto>().ReverseMap();

            //Mapiranja za kontakt osobu
            CreateMap<KontaktOsoba, KontaktOsobaDto>().ReverseMap();
            CreateMap<KontaktOsoba, KontaktOsobaCreateDto>().ReverseMap();
            CreateMap<KontaktOsoba, KontaktOsobaUpdateDto>().ReverseMap();

            //Mapiranja za kupca
            CreateMap<Kupac, KupacDto>().ReverseMap();
            CreateMap<Kupac, KupacCreateDto>().ReverseMap();
            CreateMap<Kupac, KupacUpdateDto>().ReverseMap();

            CreateMap<Kupac, KupacBasicInfoDto>().ReverseMap();
            CreateMap<Kupac, KupacWithTipDto>().ReverseMap();

            //Mapiranje za PL
            CreateMap<PravnoLice, PravnoLiceDto>().ReverseMap();
            CreateMap<PravnoLice, PravnoLiceCreateDto>().ReverseMap();
            CreateMap<PravnoLice, PravnoLiceUpdateDto>().ReverseMap();

            //Mapiranje za FL
            CreateMap<FizickoLice, FizickoLiceDto>().ReverseMap();
            CreateMap<FizickoLice, FizickoLiceCreateDto>().ReverseMap();
            CreateMap<FizickoLice, FizickoLiceUpdateDto>().ReverseMap();


        }
    }
}
