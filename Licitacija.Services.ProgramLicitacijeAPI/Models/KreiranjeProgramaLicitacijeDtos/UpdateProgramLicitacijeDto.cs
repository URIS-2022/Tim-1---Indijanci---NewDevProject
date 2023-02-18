namespace Licitacija.Services.ProgramLicitacijeAPI.Models.KreiranjeProgramaLicitacijeDtos
{
    public class UpdateProgramLicitacijeDto
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
        /// Id  Faze licitacije (strani kljuc, mikroservis Licitacija).
        /// </summary>
        public Guid? FazaLicitacijeId { get; set; }
    }
}
