using AutoMapper;
using Licitacija.Services.KupacAPI.DTOs.ExchangeDTOs;
using Licitacija.Services.KupacAPI.DTOs.KupacDTO;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;
using Licitacija.Services.KupacAPI.ServiceCalls;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.KupacAPI.Controllers
{
    [ApiController]
    [Route("api/kupac")]
    [Produces("application/json", "application/xml")]
    public class KupacController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKupacRepository _kupacRepository;
        private readonly IAdresaService _adresaService;
        private readonly IMapper _mapper;

        public KupacController(IUnitOfWork unitOfWork, IKupacRepository kupacRepository, IMapper mapper, IAdresaService adresaService)
        {
            _unitOfWork = unitOfWork;
            _kupacRepository = kupacRepository;
            _adresaService = adresaService; 
            _mapper = mapper;   
        }

        /// <summary>
        /// Vraća sve kupce.
        /// </summary>
        /// <returns>Lista kupaca.</returns>
        /// <response code="200">Vraća listu kupaca</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet]
        public async Task<IActionResult> GetKupci()
        {
            try
            {
                var kupci = await _kupacRepository.GetAll();

                if (kupci == null) return NoContent();

                var results = _mapper.Map<List<KupacDto>>(kupci);

                foreach (var result in results)
                {
                    AdresaDto adresa = _adresaService.GetAdresaById((Guid)result.AdresaId).Result;
                    result.Adresa = adresa;
                }

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Vraća jednog kupca na osnovu ID-ja kupca.
        /// </summary>
        /// <param name="id">ID kupca</param>
        /// <returns>Jedan kupac.</returns>
        /// <response code="200">Vraća traženog kupca</response>
        /// <response code="404">Nije pronađen nijedan kupac sa datim ID kupca</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet("{id:guid}", Name = "GetKupac")]
        public async Task<IActionResult> GetKupac(Guid id)
        {
            try
            {
                var kupac = await _kupacRepository.Get(id);

                if (kupac == null) return NotFound();

                var result = _mapper.Map<KupacDto>(kupac);

                AdresaDto adresa = _adresaService.GetAdresaById((Guid)result.AdresaId).Result;

                result.Adresa = adresa;

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Kreira novog kupca.
        /// </summary>
        /// <param name="kupacDTO">Model kupca</param>
        /// <returns>Potvrda o kreiranom kupcu.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje novog kupca \
        /// POST /api/kupac \
        /// {     \
        ///     "brojTel1": "063427381", \
        ///     "brojTel2": null, \
        ///     "email": "mailexpl@gmail.com", \
        ///     "brojRacuna":"180-453345-67", \
        ///     "ostvarenaPovrsina": 100, \
        ///     "imaZabranu": false,
        ///     "datumPocetkaZabrane": null, \
        ///     "duzinaTrajanjaZabrane": null, \
        ///     "datumPrestankaZabrane": null, \
        ///     "tipKupca": "pravno" \
        ///     "priroitetId":"8302A0FD-A699-4ED0-97EA-37AB4F618801" \
        ///     "adresaId":"930230FD-A699-4ED0-97EA-37AB4F618801"
        ///     
        /// }
        /// </remarks>
        /// <response code="201">Vraća kreiranog kupca</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpPost]
        public async Task<IActionResult> CreateKupac([FromBody] KupacCreateDto kupacDTO)
        {

            try
            {
                var kupac = _mapper.Map<Kupac>(kupacDTO);

                kupac.KupacId = Guid.NewGuid();

                await _unitOfWork.Kupac.Insert(kupac);

                await _unitOfWork.Save();

                return CreatedAtRoute("GetKupac", new { id = kupac.KupacId }, kupac);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Insert error.");
            }
        }

        /// <summary>
        /// Ažurira jednog kupca.
        /// </summary>
        /// <param name="kupacDTO">Model kupca koji se ažurira</param>
        /// <returns>Potvrdu o modifikovanom kupcu.</returns>
        /// <response code="200">Kupac uspesno azuriran</response>
        /// <response code="404">Kupac koji se ažurira nije pronađen</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpPut]
        public async Task<IActionResult> UpdateKupac([FromBody] KupacUpdateDto kupacDTO)
        {
            try
            {
                var kupac = await _unitOfWork.Kupac.Get(i => i.KupacId == kupacDTO.KupacId);

                if (kupac == null) return NotFound();

                _mapper.Map(kupacDTO, kupac);

                _unitOfWork.Kupac.Update(kupac);

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
        /// Vrši brisanje jednog kupca na osnovu ID-ja kupca.
        /// </summary>
        /// <param name="id">ID kupca</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Kupac uspešno obrisano</response>
        /// <response code="404">Nije pronađen kupac za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, OperaterNadmetanja, TehnickiSekretar")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteKupac(Guid id)
        {
            try
            {
                var kupac = await _unitOfWork.Kupac.Get(i => i.KupacId == id);

                if (kupac == null) return NotFound();

                await _unitOfWork.Kupac.Delete(id);

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
        /// Vraća jednog kupca na osnovu ID-ja kupca (samo osnovne informacije o kupcu).
        /// </summary>
        /// <param name="kupacId">ID kupca</param>
        /// <returns>Jedan kupac.</returns>
        /// <response code="200">Vraća traženog kupca</response>
        /// <response code="404">Nije pronađen nijedan kupac sa datim ID kupca</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet("kupacOsnovneInfo/{kupacId:guid}")]
        public async Task<IActionResult> GetKupacBasicInfo(Guid kupacId)
        {
            try
            {
                var kupac = await _kupacRepository.GetKupacBasicInfo(kupacId);

                if (kupac == null) return NotFound();

                var result = _mapper.Map<KupacBasicInfoDto>(kupac);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Vraća jednog kupca na osnovu ID-ja kupca (sa tipom kupca).
        /// </summary>
        /// <param name="kupacId">ID kupca</param>
        /// <returns>Jedan kupac.</returns>
        /// <response code="200">Vraća traženog kupca</response>
        /// <response code="404">Nije pronađen nijedan kupac sa datim ID kupca</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet("kupacSaTipom/{kupacId:guid}")]
        public async Task<IActionResult> GetKupacWithTip(Guid kupacId)
        {
            try
            {
                var kupac = await _kupacRepository.GetKupacWithTip(kupacId);

                if (kupac == null) return NotFound();

                var result = _mapper.Map<KupacWithTipDto>(kupac);

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
