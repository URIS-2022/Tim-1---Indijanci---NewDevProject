using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.KulturaDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.ParcelaAPI.Controllers
{
    /// <summary>
    /// Kultura kontroler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class KulturaController : ControllerBase
    {
        private readonly IKulturaRepository _kulturaRepository;
        private readonly IMapper _mapper;

        public KulturaController(IKulturaRepository kulturaRepository, IMapper mapper)
        {
            _kulturaRepository = kulturaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve kulture
        /// </summary>
        /// <returns>Lista kultura</returns>
        /// <response code="200">Vraća listu kultura</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<KulturaDto>> GetAllKulture()
        {
            try
            {
                var kulture = _kulturaRepository.GetAll();

                if (kulture == null || kulture.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<KulturaDto>>(kulture));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jednu kulturu na osnovu ID-ja kulture.
        /// </summary>
        /// <param name="id">ID kulture</param>
        /// <returns>Jedna kultura.</returns>
        /// <response code="200">Vraća traženu kulturu</response>
        /// <response code="404">Nije pronađen nijedna kultura sa datim ID kulture</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KulturaDto> GetKultura(Guid id)
        {
            try
            {
                var kultura = _kulturaRepository.GetKultura(id);

                if (kultura == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<KulturaDto>(kultura));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novu kulturu.
        /// </summary>
        /// <param name="kulturaDTO">Model kultura</param>
        /// <returns>Potvrda o kreiranoj kulturi.</returns>
        /// <response code="201">Vraća kreiranu kulturu</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KulturaDto> CreateKultura([FromBody] KulturaCreateDto kulturaDTO)
        {
            try
            {
                Kultura kultura = _mapper.Map<Kultura>(kulturaDTO);
                _kulturaRepository.InsertKultura(kultura);
                _kulturaRepository.Save();
                return Created("GetKultura", _mapper.Map<KulturaDto>(kultura));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu kulturu.
        /// </summary>
        /// <param name="kulturaDTO">Model kulture koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj kulturi.</returns>
        /// <response code="200">Vraća ažuriranu kulturu</response>
        /// <response code="404">Kultura koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<KulturaDto> UpdateKultura([FromBody] KulturaUpdateDto kulturaDTO)
        {
            try
            {
                var kulturaToUpdate = _kulturaRepository.GetKultura(kulturaDTO.KulturaId);

                if (kulturaToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(kulturaDTO, kulturaToUpdate);
                _kulturaRepository.Save();
                return Ok(_mapper.Map<KulturaDto>(kulturaToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne kulture na osnovu ID-ja kulture.
        /// </summary>
        /// <param name="id">ID kulture</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Kultura uspešno obrisana</response>
        /// <response code="404">Nije pronađena kultura za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteKultura(Guid id)
        {
            try
            {
                var kultura = _kulturaRepository.GetKultura(id);

                if (kultura == null)
                {
                    return NotFound();
                }

                _kulturaRepository.DeleteKultura(id);
                _kulturaRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}
