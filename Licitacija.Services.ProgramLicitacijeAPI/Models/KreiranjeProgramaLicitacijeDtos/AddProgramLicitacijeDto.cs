namespace Licitacija.Services.ProgramLicitacijeAPI.Models.KreiranjeProgramaLicitacijeDtos
{
    public class AddProgramLicitacijeDto
    {
        /// <summary>
        /// Naziv programa
        /// </summary>
        public string? ProgramNaziv { get; set; }

        /// <summary>
        /// Id  Faze licitacije (strani kljuc, mikroservis Licitacija).
        /// </summary>
        public Guid? FazaLicitacijeId { get; set; }
    }
}
