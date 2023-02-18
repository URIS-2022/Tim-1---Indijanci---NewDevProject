using AutoMapper;
using Licitacija.Services.ZalbaAPI.DTOs.TipZalbeDTOs;
using Licitacija.Services.ZalbaAPI.Entities;
using Licitacija.Services.ZalbaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.ZalbaAPI.Controllers
{
    /// <summary>
    /// TipZalbe controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class TipZalbeController : ControllerBase
    {
        private readonly ITipZalbeRepository _tipZalbeRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Kurs controller.
        /// </summary>
        public TipZalbeController(ITipZalbeRepository tipZalbeRepository, IMapper mapper)
        {
            _tipZalbeRepository = tipZalbeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve tipove zalbi.
        /// </summary>
        /// <returns>Lista tipova zalbi.</returns>
        /// <response code="200">Vraća listu tipova zalbi</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<TipZalbeDto>> GetAllKursevi()
        {
            try
            {
                var tipoviZalbi = _tipZalbeRepository.GetAll();

                if (tipoviZalbi == null || tipoviZalbi.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<TipZalbeDto>>(tipoviZalbi));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jedan tip zalbe na osnovu ID-ja tipa zalbe.
        /// </summary>
        /// <param name="id">ID tipa zalbe</param>
        /// <returns>Jedan tip zalbe.</returns>
        /// <response code="200">Vraća traženi tip zalbe</response>
        /// <response code="404">Nije pronađen nijedan tip zalbe sa datim ID kursa</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipZalbeDto> GetTipZalbe(Guid id)
        {
            try
            {
                var tipZalbe = _tipZalbeRepository.GetTipZalbe(id);

                if (tipZalbe == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<TipZalbeDto>(tipZalbe));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novi tip zalbe.
        /// </summary>
        /// <param name="tipZalbeDto">Model tipa zalbe</param>
        /// <returns>Potvrda o kreiranom tipu zalbe.</returns>
        /// <response code="201">Vraća kreirani tip zalbe</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipZalbeDto> CreateTipZalbe([FromBody] TipZalbeCreateDto tipZalbeDto)
        {
            try
            {
                TipZalbe tipZalbe = _mapper.Map<TipZalbe>(tipZalbeDto);
                _tipZalbeRepository.InsertTipZalbe(tipZalbe);
                _tipZalbeRepository.Save();
                return Created("GetTipZalbe", _mapper.Map<TipZalbeDto>(tipZalbe));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedan tipZalbe.
        /// </summary>
        /// <param name="tipZalbeDto">Model tipa zalbe koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom tipu zalbe.</returns>
        /// <response code="200">Vraća ažuriran tip zalbe</response>
        /// <response code="404">Tip zalbe koji se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<TipZalbeDto> UpdateTipZalbe([FromBody] TipZalbeUpdateDto tipZalbeDto)
        {
            try
            {
                var tipZalbeToUpdate = _tipZalbeRepository.GetTipZalbe(tipZalbeDto.TipZalbeId);

                if (tipZalbeToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(tipZalbeDto, tipZalbeToUpdate);
                _tipZalbeRepository.Save();
                return Ok(_mapper.Map<TipZalbeDto>(tipZalbeToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog tipa zalbe na osnovu ID-ja tipa zalbe.
        /// </summary>
        /// <param name="id">ID tipa zalbe</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Tip zalbe uspešno obrisan</response>
        /// <response code="404">Nije pronađen tip zalbe za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteTipZalbe(Guid id)
        {
            try
            {
                var tipZalbe = _tipZalbeRepository.GetTipZalbe(id);

                if (tipZalbe == null)
                {
                    return NotFound();
                }

                _tipZalbeRepository.DeleteTipZalbe(id);
                _tipZalbeRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
