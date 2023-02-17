using AutoMapper;
using Licitacija.Services.DokumentAPI.Entities;
using Licitacija.Services.DokumentAPI.Models.TipGarancijeDtos;
using Licitacija.Services.DokumentAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.DokumentAPI.Controllers
{
    /// <summary>
    /// Tip garancije kontroler.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class TipGarancijeController : ControllerBase
    {
        private readonly ITipGarancijeRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Tip garancije kontroler kontroler.
        /// </summary>
        public TipGarancijeController(ITipGarancijeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve tipove garancije.
        /// </summary>
        /// <returns>Lista tipova garancije.</returns>
        /// <response code="200">Vraća listu tipova garancije</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TipGarancije>>> GetTipoveGarancije()
        {
            try
            {
                var tipoviGarancije = await _repository.GetAllTipGarancije();

                if (tipoviGarancije.Count > 0)
                {
                    return Ok(tipoviGarancije);
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
        /// Vraća tip garancije po id.
        /// </summary>
        /// <returns>Tip garancije.</returns>
        /// <response code="200">Vraća tip garancije po id</response>
        /// <response code="404">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<TipGarancije>>> GetTipGarancije([FromRoute] Guid id)
        {
            try
            {
                var tipGarancije = await _repository.GetTipGarancijeById(id);

                return tipGarancije != null ? Ok(tipGarancije) : NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Kreira novi tip garancije.
        /// </summary>
        /// <param name="AddTipGarancijeDto">Model tipa garancije</param>
        /// <returns>Potvrda o kreiranom tipu garancije.</returns>
        /// <response code="201">Vraća kreirani tip garancije</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NoviTipGarancijeDto>> AddNoviTipGarancije([FromBody] AddTipGarancijeDto addTipGarancije)
        {
            try
            {
                var tipGarancije = _repository.AddTipGarancije(addTipGarancije);
                await _repository.Save();

                return Created("api/tipGarancije", _mapper.Map<NoviTipGarancijeDto>(tipGarancije));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedan tip garancije.
        /// </summary>
        /// <param name="UpdateTipGarancijeDto">Model tipa garancije koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom tipu garancije.</returns>
        /// <response code="200">Vraća ažuriran tip garancije</response>
        /// <response code="404">Tip garancije koji se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateTipGarancijeDto>> UpdateTipGarancije([FromBody] UpdateTipGarancijeDto updateTipGarancijeDto)
        {
            try
            {
                var tipGarancije = await _repository.UpdateTipGarancije(updateTipGarancijeDto);

                if (tipGarancije == null)
                {
                    return NotFound();
                }

                var toReturn = _mapper.Map(tipGarancije, updateTipGarancijeDto);

                await _repository.Save();

                return Ok(toReturn);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog tipa garancije po id.
        /// </summary>
        /// <param name="id">ID tipa garancije</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Tip garancije uspešno obrisan</response>
        /// <response code="404">Nije pronađen tip garancije za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipGarancije(Guid id)
        {
            try
            {
                bool isDeleted = await _repository.DeleteTipGarancijeById(id);

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
