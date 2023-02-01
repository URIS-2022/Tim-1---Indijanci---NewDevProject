using AutoMapper;
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
            CreateMap<Prioritet, PrioritetDTO>().ReverseMap();
            CreateMap<Prioritet, PrioritetCreateDTO>().ReverseMap();
            CreateMap<Prioritet, PrioritetUpdateDTO>().ReverseMap();

            //Mapiranja za kontakt osobu
            CreateMap<KontaktOsoba, KontaktOsobaDTO>().ReverseMap();
            CreateMap<KontaktOsoba, KontaktOsobaCreateDTO>().ReverseMap();
            CreateMap<KontaktOsoba, KontaktOsobaUpdateDTO>().ReverseMap();

            //Mapiranja za kupca
            CreateMap<Kupac, KupacDTO>().ReverseMap();
            CreateMap<Kupac, KupacCreateDTO>().ReverseMap();
            CreateMap<Kupac, KupacUpdateDTO>().ReverseMap();

            //Mapiranje za PL
            CreateMap<PravnoLice, PravnoLiceDTO>().ReverseMap();
            CreateMap<PravnoLice, PravnoLiceCreateDTO>().ReverseMap();
            CreateMap<PravnoLice, PravnoLiceUpdateDTO>().ReverseMap();

            //Mapiranje za FL
            CreateMap<FizickoLice, FizickoLiceDTO>().ReverseMap();
            CreateMap<FizickoLice, FizickoLiceCreateDTO>().ReverseMap();
            CreateMap<FizickoLice, FizickoLiceUpdateDTO>().ReverseMap();


        }
    }
}
