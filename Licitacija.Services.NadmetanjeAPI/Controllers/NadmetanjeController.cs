using AutoMapper;
using Licitacija.Services.NadmetanjeAPI.Entities;
using Licitacija.Services.NadmetanjeAPI.Models;
using Licitacija.Services.NadmetanjeAPI.Repositories;
using Licitacija.Services.NadmetanjeAPI.ServiceCalls;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.NadmetanjeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class NadmetanjeController : ControllerBase
    {
        private readonly INadmetanjeRepository _nadmetanjeRepository;
        private readonly IFazaLicitacijeService _fazaLicitacijeService;
        private readonly ILicitacijaService _licitacijaService;
        private readonly IKatastarskaOpstinaService _katastarskaOpstinaService;
        private readonly IAdresaService _adresaService;
        private readonly IMapper _mapper;

        public NadmetanjeController(INadmetanjeRepository nadmetanjeRepository, ILicitacijaService licitacijaService,
            IAdresaService adresaService, IKatastarskaOpstinaService katastarskaOpstinaService,
            IFazaLicitacijeService fazaLicitacijeService, IMapper mapper)
        {
            _nadmetanjeRepository = nadmetanjeRepository;
            _fazaLicitacijeService = fazaLicitacijeService;
            _katastarskaOpstinaService = katastarskaOpstinaService;
            _licitacijaService = licitacijaService;
            _adresaService = adresaService;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sva nadmetanja.
        /// </summary>
        /// <returns>Lista nadmetanja.</returns>
        /// <response code="200">Vraća listu nadmetanja</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<List<NadmetanjeDto>> GetAllNadmetanja()
        {
            try
            {
                var nadmetanje = _nadmetanjeRepository.GetAll();

                if (nadmetanje == null || nadmetanje.Count == 0)
                {
                    return NoContent();
                }

                var result = _mapper.Map<List<NadmetanjeDto>>(nadmetanje);

                foreach(var nadmetanjeSubject in result)
                {
                    LicitacijaDto licitacija = _licitacijaService.GetLicitacijaById(nadmetanjeSubject.LicitacijaId).Result;
                    nadmetanjeSubject.Licitacija = licitacija;

                    FazaDto faza = _fazaLicitacijeService.GetFazaLicitacijeById(nadmetanjeSubject.FazaId).Result;
                    nadmetanjeSubject.Faza = faza;

                    AdresaDto adresa = _adresaService.GetAdresaById(nadmetanjeSubject.AdresaId).Result;
                    nadmetanjeSubject.Adresa = adresa;

                    KatastarskaOpstinaDto katastarskaOpstina = _katastarskaOpstinaService.GetKatastarskaOpstinaById(nadmetanjeSubject.KatOpstinaId).Result;
                    nadmetanjeSubject.KatastarskaOpstina = katastarskaOpstina;
                }

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vraća jedno nadmetanje na osnovu ID-ja nadmetanja.
        /// </summary>
        /// <param name="id">ID nadmetanja</param>
        /// <returns>Jedno nadmetanje.</returns>
        /// <response code="200">Vraća traženo nadmetanje</response>
        /// <response code="404">Nije pronađeno nijedno nadmetanje sa datim ID nadmetanja</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<NadmetanjeDto> GetNadmetanje(Guid id)
        {
            try
            {
                var nadmetanje = _nadmetanjeRepository.GetNadmetanje(id);

                if (nadmetanje == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<NadmetanjeDto>(nadmetanje);

                LicitacijaDto licitacija = _licitacijaService.GetLicitacijaById(result.LicitacijaId).Result;
                result.Licitacija = licitacija;

                FazaDto faza = _fazaLicitacijeService.GetFazaLicitacijeById(result.FazaId).Result;
                result.Faza = faza;

                AdresaDto adresa = _adresaService.GetAdresaById(result.AdresaId).Result;
                result.Adresa = adresa;

                KatastarskaOpstinaDto katastarskaOpstina = _katastarskaOpstinaService.GetKatastarskaOpstinaById(result.KatOpstinaId).Result;
                result.KatastarskaOpstina = katastarskaOpstina;


                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Kreira novo nadmetanje.
        /// </summary>
        /// <param name="nadmetanjeDto">Model nadmetanja</param>
        /// <returns>Potvrda o kreiranom nadmetanju.</returns>
        /// <response code="201">Vraća kreirano nadmetanje</response>
        /// <response code="500">Serverska greška</response>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<NadmetanjeDto> CreateNadmetanje([FromBody] NadmetanjeCreateDto nadmetanjeDto)
        {
            try
            {
                Nadmetanje nadmetanje = _mapper.Map<Nadmetanje>(nadmetanjeDto);
                _nadmetanjeRepository.InsertNadmetanje(nadmetanje);
                _nadmetanjeRepository.Save();
                return Created("GetNadmetanje", _mapper.Map<NadmetanjeDto>(nadmetanje));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Ažurira jedno nadmetanje.
        /// </summary>
        /// <param name="nadmetanjeDto">Model nadmetanja koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom nadmetanju.</returns>
        /// <response code="200">Vraća ažurirano nadmetanje</response>
        /// <response code="404">Nadmetanje koje se ažurira nije pronađeno</response>
        /// <response code="500">Serverska greška</response>
        [HttpPut]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<NadmetanjeDto> UpdateNadmetanje([FromBody] NadmetanjeUpdateDto nadmetanjeDto)
        {
            try
            {
                var nadmetanjeToUpdate = _nadmetanjeRepository.GetNadmetanje(nadmetanjeDto.NadmetanjeId);

                if (nadmetanjeToUpdate == null)
                {
                    return NotFound();
                }

                _mapper.Map(nadmetanjeDto, nadmetanjeToUpdate);
                _nadmetanjeRepository.Save();
                return Ok(_mapper.Map<NadmetanjeDto>(nadmetanjeToUpdate));

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vrši brisanje jednog nadmetanja na osnovu ID-ja nadmetanja.
        /// </summary>
        /// <param name="id">ID nadmetanja</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Nadmetanje uspešno obrisano</response>
        /// <response code="404">Nije pronađeno nadmetanje za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public ActionResult DeleteJavno(Guid id)
        {
            try
            {
                var nadmetanje = _nadmetanjeRepository.GetNadmetanje(id);

                if (nadmetanje == null)
                {
                    return NotFound();
                }

                _nadmetanjeRepository.DeleteNadmetanje(id);
                _nadmetanjeRepository.Save();
                return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        /// <summary>
        /// Vraća jedno nadmetanje na osnovu ID-ja nadmetanja.
        /// </summary>
        /// <param name="id">ID nadmetanja</param>
        /// <returns>Jedno nadmetanje.</returns>
        /// <response code="200">Vraća traženo nadmetanje</response>
        /// <response code="404">Nije pronađeno nijedno nadmetanje sa datim ID nadmetanja</response>
        /// <response code="500">Serverska greška</response>
        [HttpGet("NadmetanjeBasic/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<NadmetanjeBasic> GetNadmetanjeBasic(Guid id)
        {
            try
            {
                var nadmetanje = _nadmetanjeRepository.GetNadmetanjeBasic(id);

                if (nadmetanje == null)
                {
                    return NotFound();
                }

                var result = _mapper.Map<NadmetanjeBasic>(nadmetanje);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
