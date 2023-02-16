using AutoMapper;
using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.DokumentDtos;
using Licitacija.Services.DokumentAPI.Models.ExchangeDtos;
using Licitacija.Services.DokumentAPI.Repositories.Interfaces;
using Licitacija.Services.DokumentAPI.ServiceCalls;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.DokumentAPI.Controllers
{
    /// <summary>
    /// Dokument kontroler.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class DokumentController : ControllerBase
    {
        private readonly IDokumentRepository _repository;
        private readonly IMapper _mapper;
        private readonly IKupacService _kupacService;

        /// <summary>
        /// Dokument kontroler kontroler.
        /// </summary>
        public DokumentController(IDokumentRepository repository, IMapper mapper, IKupacService kupacService)
        {
            _repository = repository;
            _mapper = mapper;
            _kupacService = kupacService;
        }

        /// <summary>
        /// Vraća sve dokumente.
        /// </summary>
        /// <returns>Lista dokumenata.</returns>
        /// <response code="200">Vraća listu dokumenata</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<GetDokumentDto>>> GetDokumente()
        {
            try
            {
                var dokumenti = await _repository.GetAllDokumente();

                if (dokumenti.Count > 0)
                {
                    var results = _mapper.Map<List<GetDokumentDto>>(dokumenti);

                    foreach(var result in results)
                    {
                        KupacDto? kupac = await _kupacService.GetKupacWithTip(result.KupacId);
                        result.Kupac = kupac;
                    }

                    return Ok(results);
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
        /// Vraća dokument po id.
        /// </summary>
        /// <returns>Dokument.</returns>
        /// <response code="200">Vraća dokument po id</response>
        /// <response code="404">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetDokumentDto>> GetDokument([FromRoute] Guid id)
        {
            try
            {
                var dokument = await _repository.GetDokumentById(id);

                if(dokument != null)
                {
                    var result = _mapper.Map<GetDokumentDto>(dokument);
                    result.Kupac = await _kupacService.GetKupacWithTip(result.KupacId);
                    return Ok(result);
                }
                
                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Kreira novi dokument.
        /// </summary>
        /// <param name="AddDokumentDto">Model dokumenta</param>
        /// <returns>Potvrda o kreiranom dokumentu.</returns>
        /// <response code="201">Vraća kreirani dokument</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NoviDokumentDto>> AddNoviDokument([FromBody] AddDokumentDto addDokument)
        {
            try
            {
                var dokument = _repository.AddDokument(addDokument);
                await _repository.Save();

                return Created("api/dokument", _mapper.Map<NoviDokumentDto>(dokument));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedan dokument.
        /// </summary>
        /// <param name="UpdateDokumentDto">Model dokumenta koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom dokumentu.</returns>
        /// <response code="200">Vraća ažuriran dokument</response>
        /// <response code="404">Dokument koji se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateDokumentDto>> UpdateDokument([FromBody] UpdateDokumentDto updateDokument)
        {
            try
            {
                var dokument = await _repository.UpdateDokument(updateDokument);

                if (dokument == null)
                {
                    return NotFound();
                }

                var toReturn = _mapper.Map(dokument, updateDokument);

                await _repository.Save();

                return Ok(toReturn);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog dokumenta po id.
        /// </summary>
        /// <param name="id">ID dokumenta</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Dokument uspešno obrisan</response>
        /// <response code="404">Nije pronađen dokument za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDokument(Guid id)
        {
            try
            {
                bool isDeleted = await _repository.DeleteDokumentById(id);

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
