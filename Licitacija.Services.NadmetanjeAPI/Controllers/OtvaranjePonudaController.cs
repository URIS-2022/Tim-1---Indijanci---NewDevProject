using AutoMapper;
using Licitacija.Services.NadmetanjeAPI.Entities;
using Licitacija.Services.NadmetanjeAPI.Models;
using Licitacija.Services.NadmetanjeAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.NadmetanjeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class OtvaranjePonudaController : ControllerBase
    {
        private readonly IOtvaranjePonudaRepository _otvaranjePonudaRepository;
        private readonly IMapper _mapper;

        public OtvaranjePonudaController(IOtvaranjePonudaRepository otvaranjePonudaRepository, IMapper mapper)
        {
            _otvaranjePonudaRepository = otvaranjePonudaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sva otvaranja ponuda.
        /// </summary>
        /// <returns>Lista otvaranja ponuda.</returns>
        /// <response code="200">Vraća listu otvaranja ponuda</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<OtvaranjePonudaDto>> GetAllOtvaranjePonuda()
        {
            try
            {
                var otvaranjePonuda = _otvaranjePonudaRepository.GetAll();

                if (otvaranjePonuda == null || otvaranjePonuda.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<OtvaranjePonudaDto>>(otvaranjePonuda));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vraća jedno otvaranje ponuda na osnovu ID-ja otvaranja ponuda.
        /// </summary>
        /// <param name="id">ID otvaranja ponuda</param>
        /// <returns>Jedno otvaranje ponuda.</returns>
        /// <response code="200">Vraća traženo otvaranje ponuda</response>
        /// <response code="404">Nije pronađeno nijedno otvaranje ponuda sa datim ID otvaranja ponuda</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OtvaranjePonudaDto> GetOtvaranjePonuda(Guid id)
        {
            try
            {
                var otvaranjePonuda = _otvaranjePonudaRepository.GetOtvaranjePonuda(id);

                if (otvaranjePonuda == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<OtvaranjePonudaDto>(otvaranjePonuda));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Kreira novo otvaranje ponuda.
        /// </summary>
        /// <param name="otvaranjePonudaDto">Model otvaranja ponuda</param>
        /// <returns>Potvrda o kreiranom otvaranju ponuda.</returns>
        /// <response code="201">Vraća kreirano otvaranje ponuda</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OtvaranjePonudaDto> CreateOtvaranjePonuda([FromBody] OtvaranjePonudaCreateDto otvaranjePonudaDto)
        {
            try
            {
                OtvaranjePonuda otvaranjePonuda = _mapper.Map<OtvaranjePonuda>(otvaranjePonudaDto);
                _otvaranjePonudaRepository.InsertOtvaranjePonuda(otvaranjePonuda);
                _otvaranjePonudaRepository.Save();
                return Created("GetOtvaranjePonuda", _mapper.Map<OtvaranjePonudaDto>(otvaranjePonuda));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedno otvaranje ponuda.
        /// </summary>
        /// <param name="otvaranjePonudaDto">Model otvaranja ponuda koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom otvaranju ponuda.</returns>
        /// <response code="200">Vraća ažurirano otvaranje ponuda</response>
        /// <response code="404">Otvaranje ponuda koje se ažurira nije pronađeno</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OtvaranjePonudaDto> UpdateOtvaranjePonuda([FromBody] OtvaranjePonudaUpdateDto otvaranjePonudaDto)
        {
            try
            {
                var otvaranjePonudaToUpdate = _otvaranjePonudaRepository.GetOtvaranjePonuda(otvaranjePonudaDto.OtvaranjePonudaId);

                if (otvaranjePonudaToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(otvaranjePonudaDto, otvaranjePonudaToUpdate);
                _otvaranjePonudaRepository.Save();
                return Ok(_mapper.Map<OtvaranjePonudaDto>(otvaranjePonudaToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog otvaranja ponuda na osnovu ID-ja otvaranja ponuda.
        /// </summary>
        /// <param name="id">ID otvaranja ponuda</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Otvaranja ponuda uspešno obrisano</response>
        /// <response code="404">Nije pronađeno otvaranje ponuda za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteOtvaranjePonuda(Guid id)
        {
            try
            {
                var otvaranjePonuda = _otvaranjePonudaRepository.GetOtvaranjePonuda(id);

                if (otvaranjePonuda == null)
                {
                    return NotFound();
                }

                _otvaranjePonudaRepository.DeleteOtvaranjePonuda(id);
                _otvaranjePonudaRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vraća jedno otvaranje ponuda na osnovu ID-ja otvaranja ponuda.
        /// </summary>
        /// <param name="id">ID otvaranja ponuda</param>
        /// <returns>Jedno otvaranje ponuda.</returns>
        /// <response code="200">Vraća traženo otvaranje ponuda</response>
        /// <response code="404">Nije pronađeno nijedno otvaranje ponuda sa datim ID otvaranja ponuda</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("OtvaranjePonudaBasic/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OtvaranjePonudaBasic> GetOtvaranjePonudaBasic(Guid id)
        {
            try
            {
                var otvaranjePonuda = _otvaranjePonudaRepository.GetOtvaranjePonudaBasic(id);

                if (otvaranjePonuda == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<OtvaranjePonudaBasic>(otvaranjePonuda));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
