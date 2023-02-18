using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.ParcelaAPI.DTOs.ParcelaDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;
using Licitacija.Services.ParcelaAPI.ServiceCalls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Licitacija.Services.ParcelaAPI.Controller
{
    /// <summary>
    /// Parcela kontroler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class ParcelaController : ControllerBase
    {
        private readonly IParcelaRepository _parcelaRepository;
        private readonly IKupacService _kupacService;
        private readonly IMapper _mapper;

        public ParcelaController(IParcelaRepository parcelaRepository, IKupacService kupacService, IMapper mapper)
        {
            _parcelaRepository = parcelaRepository;
            _kupacService = kupacService;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve parcele
        /// </summary>
        /// <returns>Lista parcela</returns>
        /// <response code="200">Vraća listu parcela</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<ParcelaDto>> GetAllParcele()
        {
            try
            {
                var parcele = _parcelaRepository.GetAll();

                if (parcele == null || parcele.Count == 0)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<ParcelaDto>>(parcele);

                foreach (var parcela in result)
                {
                    KupacBasicInfoDto kupac = _kupacService.GetKupacById(parcela.KupacId).Result;
                    parcela.Kupac = kupac;
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jednu parcelu na osnovu ID-ja parcele
        /// </summary>
        /// <param name="id">ID parcele</param>
        /// <returns>Jedna parcela</returns>
        /// <response code="200">Vraća traženu parcelu</response>
        /// <response code="404">Nije pronađena nijedna parcela sa datim ID parcele</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ParcelaDto> GetParcela(Guid id)
        {
            try
            {
                var parcela = _parcelaRepository.GetParcela(id);

                if (parcela == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<ParcelaDto>(parcela);
                KupacBasicInfoDto kupac = _kupacService.GetKupacById(result.KupacId).Result;
                result.Kupac = kupac;

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novu parcelu
        /// </summary>
        /// <param name="parcelaDTO">Model parcele</param>
        /// <returns>Potvrda o kreiranoj parceli</returns>
        /// <response code="201">Vraća kreiranu parcelu</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ParcelaDto> CreateParcela([FromBody] ParcelaCreateDto parcelaDTO)
        {
            try
            {
                Parcela parcela = _mapper.Map<Parcela>(parcelaDTO);
                _parcelaRepository.InsertParcela(parcela);
                _parcelaRepository.Save();
                return Created("GetParcela", _mapper.Map<ParcelaDto>(parcela));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu parcelu
        /// </summary>
        /// <param name="parcelaDTO">Model parcele koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj parceli</returns>
        /// <response code="200">Vraća ažuriranu parcelu</response>
        /// <response code="404">Parcela koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ParcelaDto> UpdateParcela([FromBody] ParcelaUpdateDto parcelaDTO)
        {
            try
            {
                var parcelaToUpdate = _parcelaRepository.GetParcela(parcelaDTO.ParcelaId);

                if (parcelaToUpdate == null)
                {
                    return NotFound();
                }


                _mapper.Map(parcelaDTO, parcelaToUpdate);
                _parcelaRepository.Save();
                return Ok(_mapper.Map<ParcelaDto>(parcelaToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne parcele na osnovu ID-ja parcele
        /// </summary>
        /// <param name="id">ID parcele</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Parcela uspešno obrisana</response>
        /// <response code="404">Nije pronađena parcela za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteParcela(Guid id)
        {
            try
            {
                var parcela = _parcelaRepository.GetParcela(id);

                if (parcela == null)
                {
                    return NotFound();
                }

                _parcelaRepository.DeleteParcela(id);
                _parcelaRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
