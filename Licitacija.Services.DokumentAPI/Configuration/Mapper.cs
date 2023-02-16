using AutoMapper;
using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.DokumentDtos;
using Licitacija.Services.DokumentAPI.Models.EksterniDokumentDtos;
using Licitacija.Services.DokumentAPI.Models.StatusDokumentaDtos;
using Licitacija.Services.DokumentAPI.Models.TipGarancijeDtos;
using Licitacija.Services.DokumentAPI.Models.UgovorOZakupuDtos;

namespace Licitacija.Services.DokumentAPI.Configuration
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<StatusDokumenta, NoviStatusDokumentaDto>().ReverseMap();
            CreateMap<StatusDokumenta, UpdateStatusDokumentaDto>().ReverseMap();

            CreateMap<Dokument, NoviDokumentDto>().ReverseMap();
            CreateMap<Dokument, UpdateDokumentDto>().ReverseMap();
            CreateMap<Dokument, GetDokumentDto>().ReverseMap();

            CreateMap<EksterniDokument, NoviEksterniDokumentDto>().ReverseMap();
            CreateMap<EksterniDokument, UpdateEksterniDokumentDto>().ReverseMap();

            CreateMap<TipGarancije, NoviTipGarancijeDto>().ReverseMap();
            CreateMap<TipGarancije, UpdateTipGarancijeDto>().ReverseMap();

            CreateMap<UgovorOZakupu, NoviUgovorOZakupuDto>().ReverseMap();
            CreateMap<UgovorOZakupu, UpdateUgovorOZakupuDto>().ReverseMap();
            CreateMap<UgovorOZakupu, GetUgovorOZakupuDto>().ReverseMap();
        }
    }
}
