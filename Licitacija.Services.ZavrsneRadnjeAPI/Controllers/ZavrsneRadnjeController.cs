using AutoMapper;
using Licitacija.Services.ZavrsneRadnjeAPI.DTOs.ExchangeDto;
using Licitacija.Services.ZavrsneRadnjeAPI.DTOs.ZavrsneRadnjeDto;
using Licitacija.Services.ZavrsneRadnjeAPI.Entities;
using Licitacija.Services.ZavrsneRadnjeAPI.Repositories.ConcreteClasses.Interfaces;
using Licitacija.Services.ZavrsneRadnjeAPI.ServiceCalls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.ZavrsneRadnjeAPI.Controllers
{
    /// <summary>
    /// Zavrsne radnje controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class ZavrsneRadnjeController : ControllerBase
    {
        private readonly IZavrsneRadnje _zavrsneRadnje;
        private readonly IFazaLicitacijeService _fazaLicitacijeService;
        private readonly IMapper _mapper;

        public ZavrsneRadnjeController(IZavrsneRadnje zavrsneRadnje, IFazaLicitacijeService fazaLicitacijeService, IMapper mapper)
        {
            _zavrsneRadnje = zavrsneRadnje;
            _fazaLicitacijeService = fazaLicitacijeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve zavrsne radnje.
        /// </summary>
        /// <returns>Lista zavrsnih radnji.</returns>
        /// <response code="200">Vraća listu zavrsnih radnji</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<ZavrsneRadnjeDto>> GetAllZavrsneRadnje()
        {
            try
            {
                var zavrsneRadnje = _zavrsneRadnje.GetAll();

                if (zavrsneRadnje == null || zavrsneRadnje.Count == 0)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<ZavrsneRadnjeDto>>(zavrsneRadnje);

                foreach (var zavrsnaRadnja in result)
                {

                    FazaLicitacijeDto fazaLicitacije = _fazaLicitacijeService.GetFazaLicitacijeById(zavrsnaRadnja.FazaId).Result;
                    zavrsnaRadnja.FazaLicitacije = fazaLicitacije;

                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jednu zavrsnu radnju na osnovu ID-ja zavrsne radnje.
        /// </summary>
        /// <param name="id">ID zavrsne radnje</param>
        /// <returns>Jedna zavrsna radnja.</returns>
        /// <response code="200">Vraća traženu zavrsnu radnju </response>
        /// <response code="404">Nije pronađena nijedna zavrsna radnja sa datim ID zavrsne radnje</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZavrsneRadnjeDto> GetZavrsnaRadnja(Guid id)
        {
            try
            {
                var zavrsnaRadnja = _zavrsneRadnje.GetZavrsneRadnje(id);

                if (zavrsnaRadnja == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<ZavrsneRadnjeDto>(zavrsnaRadnja);

                FazaLicitacijeDto fazaLicitacije = _fazaLicitacijeService.GetFazaLicitacijeById(result.FazaId).Result;
                result.FazaLicitacije = fazaLicitacije;

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novu zavrsnu radnju.
        /// </summary>
        /// <param name="zavrsnaRadnjaDTO">Model zavrsne radnje</param>
        /// <returns>Potvrda o kreiranoj zavrsnoj radnji.</returns>
        /// <response code="201">Vraća kreiranu zavrsnu radnju</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZavrsneRadnjeDto> CreateZavrsnaRadnja([FromBody] ZavrsneRadnjeCreateDto zavrsnaRadnjaDTO)
        {
            try
            {
                ZavrsneRadnje zavrsnaRadnja = _mapper.Map<ZavrsneRadnje>(zavrsnaRadnjaDTO);
                _zavrsneRadnje.InsertZavrsneRadnje(zavrsnaRadnja);
                _zavrsneRadnje.Save();
                return Created("GetZavrsnaRadnja", _mapper.Map<ZavrsneRadnje>(zavrsnaRadnja));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        /// <summary>
        /// Ažurira jednu zavrsnu radnju.
        /// </summary>
        /// <param name="zavrsnaRadnjaDTO">Model zavrsne radnje koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj zavrsnoj radnji.</returns>
        /// <response code="200">Vraća ažuriranu zavrsnu radnju radnju</response>
        /// <response code="404">Zavrsna radnja koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZavrsneRadnjeDto> UpdateZavrsnaRadnja([FromBody] ZavrsneRadnjeUpdateDto zavrsnaRadnjaDTO)
        {
            try
            {
                var zavrsnaRadnjaToUpdate = _zavrsneRadnje.GetZavrsneRadnje(zavrsnaRadnjaDTO.ZavrsnaRadnjaId);

                if (zavrsnaRadnjaToUpdate == null)
                {
                    return NotFound();
                }


                _mapper.Map(zavrsnaRadnjaDTO, zavrsnaRadnjaToUpdate);
                _zavrsneRadnje.Save();
                return Ok(_mapper.Map<ZavrsneRadnjeDto>(zavrsnaRadnjaToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        /// <summary>
        /// Vrši brisanje jedne zavrsne radnje na osnovu ID-ja zavrsne radnje.
        /// </summary>
        /// <param name="id">ID zavrsne radnje</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Zavrsna radnja uspešno obrisana</response>
        /// <response code="404">Nije pronađena zavrsna radnja za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteZavrsnaRadnja(Guid id)
        {
            try
            {
                var zavrsnaRadnja = _zavrsneRadnje.GetZavrsneRadnje(id);

                if (zavrsnaRadnja == null)
                {
                    return NotFound();
                }

                _zavrsneRadnje.DeleteZavrsneRadnje(id);
                _zavrsneRadnje.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


    }
}
