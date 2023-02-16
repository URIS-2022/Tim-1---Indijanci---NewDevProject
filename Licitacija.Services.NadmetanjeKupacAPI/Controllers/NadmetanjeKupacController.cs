using AutoMapper;
using Licitacija.Services.NadmetanjeKupacAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.NadmetanjeKupacAPI.DTOs.NadmetanjeKupacDTOs;
using Licitacija.Services.NadmetanjeKupacAPI.Entities;
using Licitacija.Services.NadmetanjeKupacAPI.Repositories.Interfaces;
using Licitacija.Services.NadmetanjeKupacAPI.ServiceCalls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.NadmetanjeKupacAPI.Controllers
{
    /// <summary>
    /// NadmetanjeKupac controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class NadmetanjeKupacController : ControllerBase
    {
        private readonly INadmetanjeKupacRepository _nadmetanjeKupacRepository;
        private readonly IKupacService _kupacService;
        private readonly INadmetanjeService _nadmetanjeService;
        private readonly IMapper _mapper;

        /// <summary>
        /// NadmetanjeKupac controller.
        /// </summary>
        public NadmetanjeKupacController(INadmetanjeKupacRepository nadmetanjeKupacRepository, IKupacService kupacService, INadmetanjeService nadmetanjeService, IMapper mapper)
        {
            _nadmetanjeKupacRepository = nadmetanjeKupacRepository;
            _kupacService = kupacService;
            _nadmetanjeService = nadmetanjeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve nadmetanjeKupac.
        /// </summary>
        /// <returns>Lista nadmetanjeKupac.</returns>
        /// <response code="200">Vraća listu nadmetanjeKupac</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<NadmetanjeKupacDto>> GetAllNadmetanjeKupac()
        {
            try
            {
                var nadmetanjeKupac = _nadmetanjeKupacRepository.GetAll();

                if (nadmetanjeKupac == null || nadmetanjeKupac.Count == 0)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<NadmetanjeKupacDto>>(nadmetanjeKupac);

                foreach (var nadmetanjeKupac1 in result)
                {

                    KupacDto kupac = _kupacService.GetKupacById(nadmetanjeKupac1.KupacId).Result;
                    nadmetanjeKupac1.Kupac = kupac;

                    NadmetanjeDto nadmetanje = _nadmetanjeService.GetNadmetanjeById(nadmetanjeKupac1.NadmetanjeId).Result;
                    nadmetanjeKupac1.Nadmetanje = nadmetanje;

                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jedno nadmetanjeKupac na osnovu ID-ja nadmetanjeKupac.
        /// </summary>
        /// <param name="id">ID nadmetanjeKupac</param>
        /// <returns>Jedno nadmetanjeKupac.</returns>
        /// <response code="200">Vraća traženo nadmetanjeKupac</response>
        /// <response code="404">Nije pronađena nijedno nadmetanjeKupac sa datim ID nadmetanjeKupac</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<NadmetanjeKupacDto> GetNadmetanjeKupac(Guid id)
        {
            try
            {
                var nadmetanjeKupac = _nadmetanjeKupacRepository.GetNadmetanjeKupac(id);

                if (nadmetanjeKupac == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<NadmetanjeKupacDto>(nadmetanjeKupac);

                KupacDto kupac = _kupacService.GetKupacById(result.KupacId).Result;
                result.Kupac = kupac;

                NadmetanjeDto nadmetanje = _nadmetanjeService.GetNadmetanjeById(result.NadmetanjeId).Result;
                result.Nadmetanje = nadmetanje;

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novo nadmetanjeKupac.
        /// </summary>
        /// <param name="nadmetanjeKupacDto">Model nadmetanjeKupac</param>
        /// <returns>Potvrda o kreiranom nadmetanjeKupac.</returns>
        /// <response code="201">Vraća kreirano nadmetanjeKupac</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<NadmetanjeKupacDto> CreateNadmetanjeKupac([FromBody] NadmetanjeKupacCreateDto nadmetanjeKupacDto)
        {
            try
            {
                NadmetanjeKupacEntity nadmetanjeKupac = _mapper.Map<NadmetanjeKupacEntity>(nadmetanjeKupacDto);
                _nadmetanjeKupacRepository.InsertNadmetanjeKupac(nadmetanjeKupac);
                _nadmetanjeKupacRepository.Save();
                return Created("GetNadmetanjeKupac", _mapper.Map<NadmetanjeKupacDto>(nadmetanjeKupac));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedno nadmetanjeKupac.
        /// </summary>
        /// <param name="nadmetanjeKupacDto">Model nadmetanjeKupac koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj nadmetanjeKupac.</returns>
        /// <response code="200">Vraća ažurirano nadmetanjeKupac</response>
        /// <response code="404">NadmetanjeKupac koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<NadmetanjeKupacDto> UpdateNadmetanjeKupac([FromBody] NadmetanjeKupacUpdateDto nadmetanjeKupacDto)
        {
            try
            {
                var nadmetanjeKupacToUpdate = _nadmetanjeKupacRepository.GetNadmetanjeKupac(nadmetanjeKupacDto.NadmetanjeKupacId);

                if (nadmetanjeKupacToUpdate == null)
                {
                    return NotFound();
                }


                _mapper.Map(nadmetanjeKupacDto, nadmetanjeKupacToUpdate);
                _nadmetanjeKupacRepository.Save();
                return Ok(_mapper.Map<NadmetanjeKupacDto>(nadmetanjeKupacToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog nadmetanjeKupac na osnovu ID-ja nadmetanjeKupac.
        /// </summary>
        /// <param name="id">ID nadmetanjeKupac</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">NadmetanjeKupac uspešno obrisana</response>
        /// <response code="404">Nije pronađeno nadmetanjeKupac za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteNadmetanjeKupac(Guid id)
        {
            try
            {
                var nadmetanjeKupac = _nadmetanjeKupacRepository.GetNadmetanjeKupac(id);

                if (nadmetanjeKupac == null)
                {
                    return NotFound();
                }

                _nadmetanjeKupacRepository.DeleteNadmetanjeKupac(id);
                _nadmetanjeKupacRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
