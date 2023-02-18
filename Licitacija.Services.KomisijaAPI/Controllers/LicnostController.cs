using AutoMapper;
using Licitacija.Services.KomisijaAPI.Entities;
using Licitacija.Services.KomisijaAPI.Models.LicnostDtos;
using Licitacija.Services.LicnostAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.KomisijaAPI.Controllers
{
    /// <summary>
    /// Licnost kontroler.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class LicnostController : ControllerBase
    {
        private readonly ILicnostRepository _repository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Licnost kontroler.
        /// </summary>
        public LicnostController(ILicnostRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve ličnosti.
        /// </summary>
        /// <returns>Lista ličnosti.</returns>
        /// <response code="200">Vraća listu ličnosti</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<Licnost>>> GetLicnosti()
        {
            try
            {
                var licnosti = await _repository.GetAllLicnosti();

                if (licnosti.Count > 0)
                {
                    return Ok(licnosti);
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
        /// Vraća ličnost po id.
        /// </summary>
        /// <returns>Ličnost.</returns>
        /// <response code="200">Vraća ličnost po id</response>
        /// <response code="404">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Licnost>> GetLicnost([FromRoute] Guid id)
        {
            try
            {
                var licnost = await _repository.GetLicnostById(id);

                if (licnost != null)
                {
                    return Ok(licnost);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Kreira novu ličnost.
        /// </summary>
        /// <param name="AddLicnostDto">Model ličnosti</param>
        /// <returns>Potvrda o kreiranoj ličnosti.</returns>
        /// <response code="201">Vraća kreiranu ličnost</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<NovaLicnostDto>> AddNovuLicnost([FromBody] AddLicnostDto addLicnost)
        {
            try
            {
                var licnost = _repository.AddLicnost(addLicnost);
                await _repository.Save();

                return Created("api/licnost", _mapper.Map<NovaLicnostDto>(licnost));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu ličnost.
        /// </summary>
        /// <param name="UpdateLicnostDto">Model ličnosti koja se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj ličnosti.</returns>
        /// <response code="200">Vraća ažuriranu ličnost</response>
        /// <response code="404">Ličnost koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UpdateLicnostDto>> UpdateLicnost([FromBody] UpdateLicnostDto updateLicnost)
        {
            try
            {
                var licnost = await _repository.UpdateLicnost(updateLicnost);

                if (licnost == null)
                {
                    return NotFound();
                }

                var toReturn = _mapper.Map(licnost, updateLicnost);

                await _repository.Save();

                return Ok(toReturn);

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne ličnosti po id.
        /// </summary>
        /// <param name="id">ID ličnosti</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Ličnost uspešno obrisana</response>
        /// <response code="404">Nije pronađena ličnost za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicnost(Guid id)
        {
            try
            {
                bool isDeleted = await _repository.DeleteLicnostById(id);

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
