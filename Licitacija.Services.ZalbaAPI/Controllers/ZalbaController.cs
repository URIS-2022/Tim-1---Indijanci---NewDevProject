using AutoMapper;
using Licitacija.Services.ZalbaAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.ZalbaAPI.DTOs.ZalbaDTOs;
using Licitacija.Services.ZalbaAPI.Entities;
using Licitacija.Services.ZalbaAPI.Repositories.Interfaces;
using Licitacija.Services.ZalbaAPI.ServiceCalls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.ZalbaAPI.Controllers
{
    /// <summary>
    /// Zalba controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class ZalbaController : ControllerBase
    {
        private readonly IZalbaRepository _zalbaRepository;
        private readonly IKupacService _kupacService;
        private readonly IFazaLicitacijeService _fazaLicitacijeService;
        private readonly IMapper _mapper;

        /// <summary>
        /// Uplata controller.
        /// </summary>
        public ZalbaController(IZalbaRepository zalbaRepository, IKupacService kupacService, IFazaLicitacijeService fazaLicitacijeService, IMapper mapper)
        {
            _zalbaRepository = zalbaRepository;
            _kupacService = kupacService;
            _fazaLicitacijeService = fazaLicitacijeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve zalbe.
        /// </summary>
        /// <returns>Lista zalbi.</returns>
        /// <response code="200">Vraća listu zalbi</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<ZalbaDto>> GetAllZalbe()
        {
            try
            {
                var zalbe = _zalbaRepository.GetAll();

                if (zalbe == null || zalbe.Count == 0)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<ZalbaDto>>(zalbe);

                foreach (var zalba in result)
                {   

                    KupacDto kupac = _kupacService.GetKupacById(zalba.KupacId).Result;
                    zalba.Kupac = kupac;

                    FazaLicitacijeDto fazaLicitacije = _fazaLicitacijeService.GetFazaLicitacijeById(zalba.FazaId).Result;
                    zalba.FazaLicitacije = fazaLicitacije;

                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jednu zalbu na osnovu ID-ja zalbe.
        /// </summary>
        /// <param name="id">ID zalbe</param>
        /// <returns>Jedna zalba.</returns>
        /// <response code="200">Vraća traženu zalbu</response>
        /// <response code="404">Nije pronađena nijedna zalba sa datim ID uplate</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZalbaDto> GetZalba(Guid id)
        {
            try
            {
                var zalba = _zalbaRepository.GetZalba(id);

                if (zalba == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<ZalbaDto>(zalba);

                KupacDto kupac = _kupacService.GetKupacById(result.KupacId).Result;
                result.Kupac = kupac;

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
        /// Kreira novu zalbu.
        /// </summary>
        /// <param name="zalbaDto">Model zalbe</param>
        /// <returns>Potvrda o kreiranoj zalbi.</returns>
        /// <response code="201">Vraća kreiranu zalbu</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZalbaDto> CreateZalba([FromBody] ZalbaCreateDto zalbaDto)
        {
            try
            {
                Zalba zalba = _mapper.Map<Zalba>(zalbaDto);
                _zalbaRepository.InsertZalba(zalba);
                _zalbaRepository.Save();
                return Created("GetZalba", _mapper.Map<ZalbaDto>(zalba));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jednu zalbu.
        /// </summary>
        /// <param name="zalbaDto">Model zalbe koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj zalbi.</returns>
        /// <response code="200">Vraća ažuriranu zalbu</response>
        /// <response code="404">Uplata koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ZalbaDto> UpdateZalba([FromBody] ZalbaUpdateDto zalbaDto)
        {
            try
            {
                var zalbaToUpdate = _zalbaRepository.GetZalba(zalbaDto.ZalbaId);

                if (zalbaToUpdate == null)
                {
                    return NotFound();
                }


                _mapper.Map(zalbaDto, zalbaToUpdate);
                _zalbaRepository.Save();
                return Ok(_mapper.Map<ZalbaDto>(zalbaToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jedne zalbe na osnovu ID-ja zalbe.
        /// </summary>
        /// <param name="id">ID zalbe</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Zalba uspešno obrisana</response>
        /// <response code="404">Nije pronađena zalba za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteZalba(Guid id)
        {
            try
            {
                var zalba = _zalbaRepository.GetZalba(id);

                if (zalba == null)
                {
                    return NotFound();
                }

                _zalbaRepository.DeleteZalba(id);
                _zalbaRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
