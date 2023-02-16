using AutoMapper;
using Licitacija.Services.AdresaAPI.DTOs.Adresa;
using Licitacija.Services.AdresaAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.AdresaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.AdresaAPI.Controllers
{
    [Route("api/adresa")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class AdresaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdresaRepository _adresaRepository;
        private readonly IMapper _mapper;

        public AdresaController(IUnitOfWork unitOfWork, IAdresaRepository adresaRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _adresaRepository = adresaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve adrese.
        /// </summary>
        /// <returns>Lista adresa.</returns>
        /// <response code="200">Vraća listu adresa</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet]
        public async Task<IActionResult> GetAdrese()
        {
            try
            {
                var adrese = await _adresaRepository.GetAll();

                if (adrese == null) return NoContent();

                var results = _mapper.Map<List<AdresaDto>>(adrese);

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Vraća jednu adresu na osnovu ID-ja adrese.
        /// </summary>
        /// <param name="id">ID adrese</param>
        /// <returns>Jedna adresa.</returns>
        /// <response code="200">Vraća traženu adresu</response>
        /// <response code="404">Nije pronađena nijedna adresa sa datim ID adrese</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet("{id:guid}", Name = "GetAdresa")]
        public async Task<IActionResult> GetAdresa(Guid id)
        {
            try
            {
                var adresa = await _adresaRepository.Get(id);

                if (adresa == null) return NotFound();

                var result = _mapper.Map<AdresaDto>(adresa);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Kreira novu adresu.
        /// </summary>
        /// <param name="adresaDTO">Model adrese</param>
        /// <returns>Potvrda o kreiranoj adresi.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje nove adrese \
        /// POST /api/adresa \
        /// {     \
        ///     "ulica": "test ulica", \
        ///     "broj": "444", \
        ///     "mesto": "test mesto", \
        ///     "postanskiBroj": "21000", \
        ///     "drzavaId": "4563cf92-b8d0-4574-9b40-a725f884da36" , \
        /// }
        /// </remarks>
        /// <response code="201">Vraća kreiranu adresu</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, TehnickiSekretar, Operater")]
        [HttpPost]
        public async Task<IActionResult> CreateAdresa([FromBody] AdresaCreateDto adresaDTO)
        {

            try
            {
                var adresa = _mapper.Map<Adresa>(adresaDTO);

                adresa.AdresaId = Guid.NewGuid();

                await _unitOfWork.Adresa.Insert(adresa);

                await _unitOfWork.Save();

                return CreatedAtRoute("GetAdresa", new { id = adresa.AdresaId }, adresa);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Insert error.");
            }
        }

        /// <summary>
        /// Ažurira jednu adresu.
        /// </summary>
        /// <param name="adresaDTO">Model adrese koja se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj adresi.</returns>
        /// <response code="200">Vraća ažuriranu adresu</response>
        /// <response code="404">Adresa koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, TehnickiSekretar, Operater")]
        [HttpPut]
        public async Task<IActionResult> UpdateAdresa([FromBody] AdresaUpdateDto adresaDTO)
        {

            try
            {
                var adresa = await _adresaRepository.Get(adresaDTO.AdresaId);

                if (adresa == null) return NotFound();

                _mapper.Map(adresaDTO, adresa);

                _unitOfWork.Adresa.Update(adresa);

                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Update error.");
            }
        }

        /// <summary>
        /// Vrši brisanje jedne adrese na osnovu ID-ja adrese.
        /// </summary>
        /// <param name="id">ID adrese</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Adresa uspešno obrisana</response>
        /// <response code="404">Nije pronađena adresa za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, TehnickiSekretar, Operater")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAdresa(Guid id)
        {
            try
            {
                var adresa = await _adresaRepository.Get(id);

                if (adresa == null) return NotFound();

                await _unitOfWork.Adresa.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Delete error.");
            }
        }

        /// <summary>
        /// Vraća jednu adresu bez podataka o drzavi na osnovu ID-ja adrese.
        /// </summary>
        /// <param name="adresaId">ID adrese</param>
        /// <returns>Jedna adresa.</returns>
        /// <response code="200">Vraća traženu adresu</response>
        /// <response code="404">Nije pronađena nijedna adresa sa datim ID adrese</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet("adresaBezDrzave/{adresaId:guid}")]
        public async Task<IActionResult> GetAdresaWithoutDrzava(Guid adresaId)
        {
            try
            {
                var adresa = await _adresaRepository.GetAdresaWithoutDrzava(adresaId);

                if (adresa == null) return NotFound();

                var result = _mapper.Map<AdresaExchangeDto>(adresa);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
