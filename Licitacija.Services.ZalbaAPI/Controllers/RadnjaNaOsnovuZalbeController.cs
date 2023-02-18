using AutoMapper;
using Licitacija.Services.ZalbaAPI.DTOs.RadnjaNaOsnovuZalbeDTOs;
using Licitacija.Services.ZalbaAPI.Entities;
using Licitacija.Services.ZalbaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.ZalbaAPI.Controllers
{
    /// <summary>
    /// RadnjaNaOsnovuZalbe controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class RadnjaNaOsnovuZalbeController : ControllerBase
    {
        private readonly IRadnjaNaOsnovuZalbeRepository _radnjaNaOsnovuZalbeRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// RadnjaNaOsnovuZalbe controller.
        /// </summary>
        public RadnjaNaOsnovuZalbeController(IRadnjaNaOsnovuZalbeRepository radnjaNaOsnovuZalbeRepository, IMapper mapper)
        {
            _radnjaNaOsnovuZalbeRepository = radnjaNaOsnovuZalbeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve radnje na osnovu zalbe.
        /// </summary>
        /// <returns>Lista radnji na osnovu zalbe.</returns>
        /// <response code="200">Vraća listu radnji na osnovu zalbe</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<RadnjaNaOsnovuZalbeDto>> GetAllRadnjaNaOsnovuZalbe()
        {
            try
            {
                var radnjaNaOsnovuZalbe = _radnjaNaOsnovuZalbeRepository.GetAll();

                if (radnjaNaOsnovuZalbe == null || radnjaNaOsnovuZalbe.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<RadnjaNaOsnovuZalbeDto>>(radnjaNaOsnovuZalbe));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jednu radnju na osnovu zalbe na osnovu ID-ja radnje na osnovu zalbe.
        /// </summary>
        /// <param name="id">ID radnje na osnovu zalbe</param>
        /// <returns>Jedna radnja na osnovu zalbe.</returns>
        /// <response code="200">Vraća traženu radnju na osnovu zalbe</response>
        /// <response code="404">Nije pronađena nijedna radnja na osnovu zalbe sa datim ID radnje na osnovu zalbe</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RadnjaNaOsnovuZalbeDto> GetRadnjaNaOsnovuZalbe(Guid id)
        {
            try
            {
                var radnjaNaOsnovuZalbe = _radnjaNaOsnovuZalbeRepository.GetRadnjaNaOsnovuZalbe(id);

                if (radnjaNaOsnovuZalbe == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<RadnjaNaOsnovuZalbeDto>(radnjaNaOsnovuZalbe));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novu radnju na osnovu zalbe.
        /// </summary>
        /// <param name="radnjaNaOsnovuZalbeDto">Model radnje na osnovu zalbe</param>
        /// <returns>Potvrda o kreiranoj radnji na osnovu zalbe.</returns>
        /// <response code="201">Vraća kreiranu radnju na osnovu zalbe</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RadnjaNaOsnovuZalbeDto> CreateRadnjaNaOsnovuZalbe([FromBody] RadnjaNaOsnovuZalbeCreateDto radnjaNaOsnovuZalbeDto)
        {
            try
            {
                RadnjaNaOsnovuZalbe radnjaNaOsnovuZalbe = _mapper.Map<RadnjaNaOsnovuZalbe>(radnjaNaOsnovuZalbeDto);
                _radnjaNaOsnovuZalbeRepository.InsertRadnjaNaOsnovuZalbe(radnjaNaOsnovuZalbe);
                _radnjaNaOsnovuZalbeRepository.Save();
                return Created("GetRadnjaNaOsnovuZalbe", _mapper.Map<RadnjaNaOsnovuZalbeDto>(radnjaNaOsnovuZalbe));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu radnju na osnovu zalbe.
        /// </summary>
        /// <param name="radnjaNaOsnovuZalbeDto">Model radnje na osnovu zalbe koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj radnji na osnovu zalbe.</returns>
        /// <response code="200">Vraća ažuriranu radnju na osnovu zalbe.</response>
        /// <response code="404">Radnja na osnovu zalbe koji se ažurira nije pronađen.</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<RadnjaNaOsnovuZalbeDto> UpdateRadnjaNaOsnovuZalbe([FromBody] RadnjaNaOsnovuZalbeUpdateDto radnjaNaOsnovuZalbeDto)
        {
            try
            {
                var radnjaNaOsnovuZalbeToUpdate = _radnjaNaOsnovuZalbeRepository.GetRadnjaNaOsnovuZalbe(radnjaNaOsnovuZalbeDto.RadnjaId);

                if (radnjaNaOsnovuZalbeToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(radnjaNaOsnovuZalbeDto, radnjaNaOsnovuZalbeToUpdate);
                _radnjaNaOsnovuZalbeRepository.Save();
                return Ok(_mapper.Map<RadnjaNaOsnovuZalbeDto>(radnjaNaOsnovuZalbeToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne radnje na osnovu zalbe na osnovu ID-ja kursa.
        /// </summary>
        /// <param name="id">ID radnje na osnovu zalbe</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Radnja na osnovu zalbe uspešno obrisana</response>
        /// <response code="404">Nije pronađena radnja na osnovu zalbe za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteRadnjaNaOsnovuZalbe(Guid id)
        {
            try
            {
                var radnja = _radnjaNaOsnovuZalbeRepository.GetRadnjaNaOsnovuZalbe(id);

                if (radnja == null)
                {
                    return NotFound();
                }

                _radnjaNaOsnovuZalbeRepository.DeleteRadnjaNaOsnovuZalbe(id);
                _radnjaNaOsnovuZalbeRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
