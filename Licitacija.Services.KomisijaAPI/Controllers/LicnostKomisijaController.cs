using AutoMapper;
using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.LicnostKomisijaDtos;
using Licitacija.Services.KomisijaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.KomisijaAPI.Controllers
{
    /// <summary>
    /// LicnostKomisija kontroler.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class LicnostKomisijaController : ControllerBase
    {
        private readonly ILicnostKomisijaRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Licnost kontroler.
        /// </summary>
        public LicnostKomisijaController(ILicnostKomisijaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve ličnosti sa komisijom.
        /// </summary>
        /// <returns>Lista ličnosti sa komisijom.</returns>
        /// <response code="200">Vraća listu ličnosti sa komisijom</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<LicnostKomisija>>> GetLicnostKomisije()
        {
            try
            {
                var licnostiKomisije = await _repository.GetAllLicnostKomisija();

                if (licnostiKomisije.Count > 0)
                {
                    return Ok(licnostiKomisije);
                }
                else
                {
                    return NoContent();
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        /// <summary>
        /// Vraća ličnost sa komisijom po id.
        /// </summary>
        /// <returns>Ličnost sa komisijom.</returns>
        /// <param name="licnostId">Id licnosti</param>
        /// <param name="komisijaId">Id komisije</param>
        /// <response code="200">Vraća ličnost sa komisijom po id</response>
        /// <response code="404">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{licnostId:Guid}/{komisijaId:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LicnostKomisija>> GetLicnostSaKomisijom([FromRoute] Guid licnostId, [FromRoute] Guid komisijaId)
        {
            try
            {
                var licnostKomisija = await _repository.GetLicnostKomisijaById(licnostId, komisijaId);

                if (licnostKomisija != null)
                {
                    return Ok(licnostKomisija);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Kreira novu ličnost sa komisijom.
        /// </summary>
        /// <param name="AddLicnostKomisijaDto">Model ličnosti sa komisijom</param>
        /// <param name="licnostId">Id ličnosti za koju se dodaje komisija</param>
        /// <returns>Potvrda o kreiranoj ličnosti sa komisijom.</returns>
        /// <response code="201">Vraća kreiranu ličnost sa komisijom</response>
        /// <response code="400">Komisija ili ličnost ne postoje u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost("{licnostId:Guid}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LicnostKomisija>> AddNovuLicnostSaKomisijom([FromBody] AddLicnostKomisijaDto addLicnostKomisija, [FromRoute] Guid licnostId)
        {
            try
            {
                var licnostKomisija = _repository.AddLicnostKomisija(addLicnostKomisija, licnostId);

                if (licnostKomisija == null)
                {
                    return BadRequest("Licnost ili komisija koju pokusavate da dodate ne postoji");
                }

                await _repository.Save();

                return Created("api/licnostKomisija", _mapper.Map<NovaLicnostKomisijaDto>(licnostKomisija));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Ažurira komisiju za licnost ličnost.
        /// </summary>
        /// <param name="licnostKomisija">Model ličnosti sa komisijom koja se ažurira</param>
        /// <param name="komisijaId">Id komisije koja postoji u bazi</param>
        /// <returns>Potvrdu o modifikovanoj ličnosti sa komisijom.</returns>
        /// <response code="200">Vraća ažuriranu ličnost sa komisijom</response>
        /// <response code="404">Ličnost sa komisijom koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut("{komisijaId:Guid}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<LicnostKomisija>> UpdateLicnost([FromBody] LicnostKomisija licnostKomisija, Guid komisijaId)
        {
            try
            {
                var licnost = await _repository.UpdateLicnostKomisija(licnostKomisija, komisijaId);

                if (licnost == null)
                {
                    return NotFound();
                }

                await _repository.Save();

                return Ok(licnost);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne ličnosti sa komisijom po id.
        /// </summary>
        /// <param name="licnostId">ID ličnosti</param>
        /// <param name="komisijaId">ID komisije</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Ličnost uspešno obrisana</response>
        /// <response code="404">Nije pronađena ličnost sa komisijom za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{licnostId:Guid}/{komisijaId:Guid}")]
        public async Task<IActionResult> DeleteLicnost([FromRoute] Guid licnostId, [FromRoute] Guid komisijaId)
        {
            try
            {
                bool isDeleted = await _repository.DeleteLicnostKomisijaById(licnostId, komisijaId);

                if (!isDeleted)
                {
                    return NotFound();
                }

                await _repository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
