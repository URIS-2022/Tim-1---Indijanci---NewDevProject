using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.OdvodnjavanjeDTOs;
using Licitacija.Services.ParcelaAPI.Entities;
using Licitacija.Services.ParcelaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.ParcelaAPI.Controllers
{
    /// <summary>
    /// Odvodnjavanje kontroler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class OdvodnjavanjeController : ControllerBase
    {
        private readonly IOdvodnjavanjeRepository _odvodnjavanjeRepository;
        private readonly IMapper _mapper;

        public OdvodnjavanjeController(IOdvodnjavanjeRepository odvodnjavanjeRepository, IMapper mapper)
        {
            _odvodnjavanjeRepository = odvodnjavanjeRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sva odvodnjavanja
        /// </summary>
        /// <returns>Lista odvodnjavanja</returns>
        /// <response code="200">Vraća listu odvodnjavanja</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<OdvodnjavanjeDto>> GetAllOdvodnjavanja()
        {
            try
            {
                var odvodnjavanja = _odvodnjavanjeRepository.GetAll();

                if (odvodnjavanja == null || odvodnjavanja.Count == 0)
                {
                    return NoContent();
                }

                return Ok(_mapper.Map<List<OdvodnjavanjeDto>>(odvodnjavanja));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jedno odvodnjavanje na osnovu ID-ja odvodnjavanja.
        /// </summary>
        /// <param name="id">ID odvodnjavanja</param>
        /// <returns>Jedno odvodnjavanje.</returns>
        /// <response code="200">Vraća traženo odvodnjavanje</response>
        /// <response code="404">Nije pronađenp nijedno odvodnjavanje sa datim ID odvodnjavanja</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OdvodnjavanjeDto> GetOdvodnjavanje(Guid id)
        {
            try
            {
                var odvodnjavanje = _odvodnjavanjeRepository.GetOdvodnjavanje(id);

                if (odvodnjavanje == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<OdvodnjavanjeDto>(odvodnjavanje));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Kreira novo odvodnjavanje.
        /// </summary>
        /// <param name="odvodnjavanjeDTO">Model odvodnjavanja</param>
        /// <returns>Potvrda o kreiranom odvodnjavanju.</returns>
        /// <response code="201">Vraća kreirano odvodnjavanje</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OdvodnjavanjeDto> CreateOdvodnjavanje([FromBody] OdvodnjavanjeCreateDto odvodnjavanjeDTO)
        {
            try
            {
                Odvodnjavanje odvodnjavanje = _mapper.Map<Odvodnjavanje>(odvodnjavanjeDTO);
                _odvodnjavanjeRepository.InsertOdvodnjavanje(odvodnjavanje);
                _odvodnjavanjeRepository.Save();
                return Created("GetOdvodnjavanje", _mapper.Map<OdvodnjavanjeDto>(odvodnjavanje));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedno odvodnjavanje.
        /// </summary>
        /// <param name="odvodnjavanjeDTO">Model odvodnjavanja koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom odvodnjavanju.</returns>
        /// <response code="200">Vraća ažurirano odvodnjavanje</response>
        /// <response code="404">Odvodnjavanje koje se ažurira nije pronađeno</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<OdvodnjavanjeDto> UpdateOdvodnjavanje([FromBody] OdvodnjavanjeUpdateDto odvodnjavanjeDTO)
        {
            try
            {
                var odvodnjavanjeToUpdate = _odvodnjavanjeRepository.GetOdvodnjavanje(odvodnjavanjeDTO.OdvodnjavanjeId);

                if (odvodnjavanjeToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(odvodnjavanjeDTO, odvodnjavanjeToUpdate);
                _odvodnjavanjeRepository.Save();
                return Ok(_mapper.Map<OdvodnjavanjeDto>(odvodnjavanjeToUpdate));

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
                var kultura = _odvodnjavanjeRepository.GetOdvodnjavanje(id);

                if (kultura == null)
                {
                    return NotFound();
                }

                _odvodnjavanjeRepository.DeleteOdvodnjavanje(id);
                _odvodnjavanjeRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


    }
}
