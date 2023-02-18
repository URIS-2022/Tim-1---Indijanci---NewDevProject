using AutoMapper;
using Licitacija.Services.UplataAPI.Entities;
using Licitacija.Services.UplataAPI.Models;
using Licitacija.Services.UplataAPI.Repositories;
using Licitacija.Services.UplataAPI.ServiceCalls;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.UplataAPI.Controllers
{
    /// <summary>
    /// Uplata controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class UplataController : ControllerBase
    {
        private readonly IUplataRepository _uplataRepository;
        private readonly IKupacService _kupacService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Uplata controller.
        /// </summary>
        public UplataController(IUplataRepository uplataRepository, IKupacService kupacService, IMapper mapper)
        {
            _uplataRepository = uplataRepository;
            _kupacService = kupacService;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve uplate.
        /// </summary>
        /// <returns>Lista uplata.</returns>
        /// <response code="200">Vraća listu uplata</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<UplataDto>> GetAllUplate()
        {
            try
            {
                var uplate = _uplataRepository.GetAll();

                if (uplate == null || uplate.Count == 0)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<UplataDto>>(uplate);

                foreach (var uplata in result)
                {
                    KupacDto kupac = _kupacService.GetKupacById(uplata.KupacId).Result;
                    uplata.Kupac = kupac;
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jednu uplatu na osnovu ID-ja uplate.
        /// </summary>
        /// <param name="id">ID uplate</param>
        /// <returns>Jedna uplata.</returns>
        /// <response code="200">Vraća traženu uplatu</response>
        /// <response code="404">Nije pronađena nijedna uplata sa datim ID uplate</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UplataDto> GetUplata(Guid id)
        {
            try
            {
                var uplata = _uplataRepository.GetUplata(id);

                if (uplata == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<UplataDto>(uplata);
                KupacDto kupac = _kupacService.GetKupacById(result.KupacId).Result;
                result.Kupac = kupac;

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novu uplatu.
        /// </summary>
        /// <param name="uplataDTO">Model uplate</param>
        /// <returns>Potvrda o kreiranoj uplati.</returns>
        /// <response code="201">Vraća kreiranu uplatu</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UplataDto> CreateUplata([FromBody] UplataCreateDto uplataDTO)
        {
            try
            {
                Uplata uplata = _mapper.Map<Uplata>(uplataDTO);
                _uplataRepository.InsertUplata(uplata);
                _uplataRepository.Save();
                return Created("GetUplata", _mapper.Map<UplataDto>(uplata));
            } 
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu uplatu.
        /// </summary>
        /// <param name="uplataDTO">Model uplate koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj uplati.</returns>
        /// <response code="200">Vraća ažuriranu uplatu</response>
        /// <response code="404">Uplata koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UplataDto> UpdateUplata([FromBody] UplataUpdateDto uplataDTO)
        {
            try
            {
                var uplataToUpdate = _uplataRepository.GetUplata(uplataDTO.UplataId);

                if(uplataToUpdate == null)
                {
                    return NotFound();
                }


                _mapper.Map(uplataDTO, uplataToUpdate);
                _uplataRepository.Save();
                return Ok(_mapper.Map<UplataDto>(uplataToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne uplate na osnovu ID-ja uplate.
        /// </summary>
        /// <param name="id">ID uplate</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Uplata uspešno obrisana</response>
        /// <response code="404">Nije pronađena uplata za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteUplata(Guid id)
        {
            try
            {
                var uplata = _uplataRepository.GetUplata(id);

                if (uplata == null)
                {
                    return NotFound();
                }

                _uplataRepository.DeleteUplata(id);
                _uplataRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vraća jednu uplatu na osnovu ID-ja uplate.
        /// </summary>
        /// <param name="id">ID uplate</param>
        /// <returns>Jedna uplata.</returns>
        /// <response code="200">Vraća traženu uplatu</response>
        /// <response code="404">Nije pronađena nijedna uplata sa datim ID uplate</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("uplataZaUgovor/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<UplataBasicDto> GetUplataZaUgovor(Guid id)
        {
            try
            {
                var uplata = _uplataRepository.GetUplata(id);

                if (uplata == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<UplataBasicDto>(uplata);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}
