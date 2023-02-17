using AutoMapper;
using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.StatusDokumentaDtos;
using Licitacija.Services.DokumentAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.DokumentAPI.Controllers
{
    /// <summary>
    /// Status dokumenta kontroler.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class StatusDokumentaController : ControllerBase
    {
        private readonly IStatusDokumentaRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Status dokumenta kontroler.
        /// </summary>
        public StatusDokumentaController(IStatusDokumentaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve statuse dokumenata.
        /// </summary>
        /// <returns>Lista statusa dokumenata.</returns>
        /// <response code="200">Vraća listu statusa dokumenata</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<StatusDokumenta>>> GetStatusiDokumenata()
        {
            try
            {
                var statusi = await _repository.GetAllStatusDokumenta();

                if(statusi.Count > 0)
                {
                    return Ok(statusi);
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
        /// Vraća status dokumenta po id.
        /// </summary>
        /// <returns>Status dokumenta.</returns>
        /// <response code="200">Vraća status dokumenta po id</response>
        /// <response code="404">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<StatusDokumenta>>> GetStatusDokumenta([FromRoute] Guid id)
        {
            try
            {
                var status = await _repository.GetStatusDokumentaById(id);

                return status != null ? Ok(status) : NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Kreira novi status dokumenta.
        /// </summary>
        /// <param name="AddStatusDokumentaDto">Model statusa dokumenta</param>
        /// <returns>Potvrda o kreiranom statusu dokumenta.</returns>
        /// <response code="201">Vraća kreirani status dokumenta</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NoviStatusDokumentaDto>> AddNoviStatusDokumenta([FromBody] AddStatusDokumentaDto addStatus)
        {
            try
            {
                var status = _repository.AddStatusDokumenta(addStatus);
                await _repository.Save();
                
                return Created("api/statusDokumenta", _mapper.Map<NoviStatusDokumentaDto>(status));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedan status dokumenta.
        /// </summary>
        /// <param name="UpdateStatusDokumentaDto">Model statusa dokumenta koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom statusu dokumenta.</returns>
        /// <response code="200">Vraća ažuriran status dokumenta</response>
        /// <response code="404">Status dokumenta koji se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateStatusDokumentaDto>> UpdateStatusDokumenta([FromBody] UpdateStatusDokumentaDto updateStatus)
        {
            try
            {
                var status = await _repository.UpdateStatusDokumenta(updateStatus);

                if (status == null)
                {
                    return NotFound();
                }

                _mapper.Map(status, updateStatus);
                await _repository.Save();
                return Ok(_mapper.Map<UpdateStatusDokumentaDto>(status));

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog statusa dokumenta po id.
        /// </summary>
        /// <param name="id">ID statusa dokumenta</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Status dokumenta uspešno obrisan</response>
        /// <response code="404">Nije pronađen status dokumenta za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStatusDokumenta(Guid id)
        {
            try
            {
                bool isDeleted = await _repository.DeleteStatusDokumentaById(id);

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
