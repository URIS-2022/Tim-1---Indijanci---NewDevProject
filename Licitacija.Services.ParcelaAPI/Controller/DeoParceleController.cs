using AutoMapper;
using Licitacija.Services.ParcelaAPI.DTOs.DeoParceleDTOs;
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
    /// DeoParcele kontroler
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class DeoParceleController : ControllerBase
    {
        private readonly IDeoParceleRepository _deoParceleRepository;
        private readonly IEtapaService _etapaService;
        private readonly IOtvaranjePonudaService _otvaranjePonudaService;
        private readonly IMapper _mapper;

        public DeoParceleController(IDeoParceleRepository deoParceleRepository, IEtapaService etapaService, IOtvaranjePonudaService otvaranjePonudaService, IMapper mapper)
        {
            _deoParceleRepository = deoParceleRepository;
            _etapaService = etapaService;
            _otvaranjePonudaService = otvaranjePonudaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve delove parcele
        /// </summary>
        /// <returns>Lista delova parcele</returns>
        /// <response code="200">Vraća listu delova parcele</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<DeoParceleDto>> GetAllDeloviParcele()
        {
            try
            {
                var deloviParcele = _deoParceleRepository.GetAll();

                if (deloviParcele == null || deloviParcele.Count == 0)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<DeoParceleDto>>(deloviParcele);

                foreach (var deoParcele in result)
                {
                    EtapaBasicInfoDto etapa = _etapaService.GetEtapaById(deoParcele.EtapaId).Result;
                    deoParcele.Etapa = etapa;
                    OtvaranjePonudaBasicInfoDto otvaranjePonuda = _otvaranjePonudaService.GetOtvaranjePonudaById(deoParcele.OtvaranjePonudaId).Result;
                    deoParcele.OtvaranjePonuda = otvaranjePonuda;
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        /// <summary>
        /// Vraća jedan deo parcele na osnovu ID-ja dela parcele
        /// </summary>
        /// <param name="id">ID dela parcele</param>
        /// <returns>Jedan deo parcele</returns>
        /// <response code="200">Vraća traženi deo parcele</response>
        /// <response code="404">Nije pronađena nijedan deo parcele sa datim ID delom parcele</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DeoParceleDto> GetDeoParcele(Guid id)
        {
            try
            {
                var deoParcele = _deoParceleRepository.GetDeoParcele(id);

                if (deoParcele == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<DeoParceleDto>(deoParcele);
                EtapaBasicInfoDto etapa = _etapaService.GetEtapaById(result.EtapaId).Result;
                result.Etapa = etapa;
                OtvaranjePonudaBasicInfoDto otvaranjePonuda = _otvaranjePonudaService.GetOtvaranjePonudaById(result.OtvaranjePonudaId).Result;
                result.OtvaranjePonuda = otvaranjePonuda;

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
        /// <param name="deoParceleDTO">Model uplate</param>
        /// <returns>Potvrda o kreiranoj uplati.</returns>
        /// <response code="201">Vraća kreiranu uplatu</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DeoParceleDto> CreateDeoParcele([FromBody] DeoParceleCreateDto deoParceleDTO)
        {
            try
            {
                DeoParcele deoParcele = _mapper.Map<DeoParcele>(deoParceleDTO);
                _deoParceleRepository.InsertDeoParcele(deoParcele);
                _deoParceleRepository.Save();
                return Created("GetDeoParcele", _mapper.Map<DeoParceleDto>(deoParcele));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedan deo parcele
        /// </summary>
        /// <param name="deoParceleDTO">Model dela parcele koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom delu parcele</returns>
        /// <response code="200">Vraća ažurirani deo parcele</response>
        /// <response code="404">Deo parcele koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<DeoParceleDto> UpdateDeoParcele([FromBody] DeoParceleUpdateDto deoParceleDTO)
        {
            try
            {
                var deoParceleToUpdate = _deoParceleRepository.GetDeoParcele(deoParceleDTO.DeoParceleId);

                if (deoParceleToUpdate == null)
                {
                    return NotFound();
                }


                _mapper.Map(deoParceleDTO, deoParceleToUpdate);
                _deoParceleRepository.Save();
                return Ok(_mapper.Map<DeoParceleDto>(deoParceleToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog dela parcele na osnovu ID-ja dela parcele
        /// </summary>
        /// <param name="id">ID dela parcele</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Deo parcele uspešno obrisan</response>
        /// <response code="404">Nije pronađen deo parcele za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteDeoParcele(Guid id)
        {
            try
            {
                var deoParcele = _deoParceleRepository.GetDeoParcele(id);

                if (deoParcele == null)
                {
                    return NotFound();
                }

                _deoParceleRepository.DeleteDeoParcele(id);
                _deoParceleRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
