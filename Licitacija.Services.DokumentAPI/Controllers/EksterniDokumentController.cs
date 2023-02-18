using AutoMapper;
using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.DokumentDtos;
using Licitacija.Services.DokumentAPI.Models.EksterniDokumentDtos;
using Licitacija.Services.DokumentAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.DokumentAPI.Controllers
{
    /// <summary>
    /// Eksterni dokument kontroler.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class EksterniDokumentController : ControllerBase
    {
        private readonly IEksterniDokumentRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Eksterni dokument kontroler.
        /// </summary>
        public EksterniDokumentController(IEksterniDokumentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve eksterne dokumente.
        /// </summary>
        /// <returns>Lista eksternih dokumenata.</returns>
        /// <response code="200">Vraća listu eksternih dokumenata</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<EksterniDokument>>> GetAllEksterneDokumente()
        {
            try
            {
                var eksterniDokumenti = await _repository.GetAllEksterneDokumente();

                if (eksterniDokumenti.Count > 0)
                {
                    return Ok(eksterniDokumenti);
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
        /// Vraća eksterni dokument po id.
        /// </summary>
        /// <returns>Eksterni dokument.</returns>
        /// <response code="200">Vraća eksterni dokument po id</response>
        /// <response code="404">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<EksterniDokument>>> GetEksterniDokument([FromRoute] Guid id)
        {
            try
            {
                var eksterniDokument = await _repository.GetEksterniDokumentById(id);

                return eksterniDokument != null ? Ok(eksterniDokument) : NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Kreira novi eksterni dokument.
        /// </summary>
        /// <param name="AddEksterniDokumentDto">Model eksternog dokumenta</param>
        /// <returns>Potvrda o kreiranom eksternom dokumentu.</returns>
        /// <response code="201">Vraća eksterni kreirani dokument</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NoviEksterniDokumentDto>> AddNoviEksterniDokument([FromBody] AddEksterniDokumentDto addEksterniDokument)
        {
            try
            {
                var eksterniDokument = _repository.AddEksterniDokument(addEksterniDokument);
                await _repository.Save();

                return Created("api/eksterniDokument", _mapper.Map<NoviEksterniDokumentDto>(eksterniDokument));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedan dokument.
        /// </summary>
        /// <param name="UpdateEksterniDokumentDto">Model dokumenta koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom dokumentu.</returns>
        /// <response code="200">Vraća ažuriran dokument</response>
        /// <response code="404">Dokument koji se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateDokumentDto>> UpdateEksterniDokument([FromBody] UpdateEksterniDokumentDto updateEksterniDokument)
        {
            try
            {
                var eksterniDokument = await _repository.UpdateEksterniDokument(updateEksterniDokument);

                if (eksterniDokument == null)
                {
                    return NotFound();
                }

                var toReturn = _mapper.Map(eksterniDokument, updateEksterniDokument);

                await _repository.Save();

                return Ok(toReturn);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog eksternog dokumenta po id.
        /// </summary>
        /// <param name="id">ID eksternog dokumenta</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Eksterni dokument uspešno obrisan</response>
        /// <response code="404">Nije pronađen eksterni dokument za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEksterniDokument(Guid id)
        {
            try
            {
                bool isDeleted = await _repository.DeleteEksterniDokumentById(id);

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
