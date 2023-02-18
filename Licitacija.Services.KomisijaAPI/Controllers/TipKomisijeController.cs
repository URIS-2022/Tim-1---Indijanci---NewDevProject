using AutoMapper;
using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.TipKomisijeDtos;
using Licitacija.Services.TipKomisijeAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.KomisijaAPI.Controllers
{
    /// <summary>
    /// Tip komisije kontroler.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class TipKomisijeController : ControllerBase
    {
        private readonly ITipKomisijeRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Tip komisije kontroler.
        /// </summary>
        public TipKomisijeController(ITipKomisijeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve tipove komisije.
        /// </summary>
        /// <returns>Lista tipova komisije.</returns>
        /// <response code="200">Vraća listu tipova komisije</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TipKomisije>>> GetTipoveKomisije()
        {
            try
            {
                var tipoviKomisije = await _repository.GetAllTipoveKomisije();

                if (tipoviKomisije.Count > 0)
                {
                    return Ok(tipoviKomisije);
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
        /// Vraća tip komisije po id.
        /// </summary>
        /// <returns>Tip komisije.</returns>
        /// <response code="200">Vraća tip komisije po id</response>
        /// <response code="404">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<TipKomisije>> GetTipKomisije([FromRoute] Guid id)
        {
            try
            {
                var tipKomisije = await _repository.GetTipKomisijeById(id);

                if (tipKomisije != null)
                {
                    return Ok(tipKomisije);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Kreira novi tip komisije.
        /// </summary>
        /// <param name="AddTipKomisijeDto">Model tipa komisije</param>
        /// <returns>Potvrda o kreiranom tipu komisije.</returns>
        /// <response code="201">Vraća kreiran tip komisije</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NoviTipKomisijeDto>> AddTipKomisije([FromBody] AddTipKomisijeDto addTipKomisije)
        {
            try
            {
                var tipKomisije = _repository.AddTipKomisije(addTipKomisije);
                await _repository.Save();

                return Created("api/tipKomisije", _mapper.Map<NoviTipKomisijeDto>(tipKomisije));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedan tip komisije.
        /// </summary>
        /// <param name="UpdateTipKomisijeDto">Model tipa komisije koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom tipu komisije.</returns>
        /// <response code="200">Vraća ažuriran tip komisije</response>
        /// <response code="404">Tip komisije koja se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateTipKomisijeDto>> UpdateTipKomisije([FromBody] UpdateTipKomisijeDto updateTipKomisije)
        {
            try
            {
                var tipKomisije = await _repository.UpdateTipKomisije(updateTipKomisije);

                if (tipKomisije == null)
                {
                    return NotFound();
                }

                var toReturn = _mapper.Map(tipKomisije, updateTipKomisije);

                await _repository.Save();

                return Ok(toReturn);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog tipa komisije po id.
        /// </summary>
        /// <param name="id">ID tipa komisije</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Tip komisije uspešno obrisan</response>
        /// <response code="404">Nije pronađen tip komisije za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipKomisije(Guid id)
        {
            try
            {
                bool isDeleted = await _repository.DeleteTipKomisijeById(id);

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
