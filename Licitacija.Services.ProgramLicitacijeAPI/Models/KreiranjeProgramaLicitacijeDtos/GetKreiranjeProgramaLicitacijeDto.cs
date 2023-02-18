
using Licitacija.Services.ProgramLicitacijeAPI.Models.ExchangeDtos;

namespace Licitacija.Services.ProgramLicitacijeAPI.Models.KreiranjeProgramaLicitacijeDtos
{
    public class GetKreiranjeProgramaLicitacijeDto
    {
        /// <summary>
        /// Id  programa.
        /// </summary>
        public Guid ProgramId { get; set; }

        /// <summary>
        /// Naziv programa
        /// </summary>
        public string? ProgramNaziv { get; set; }

        /// <summary>
        /// Id faze licitacije (strani kljuc, mikroservis Licitacija).
        /// </summary>
        public Guid? FazaLicitacijeId { get; set; }

        /// <summary>
        /// Faza licitacije (mikroservis Licitacija).
        /// </summary>
        public FazaDto? FazaLicitacije { get; set; }
    }
}
