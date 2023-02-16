using AutoMapper;
using Licitacija.Services.AdresaAPI.DTOs.Drzava;
using Licitacija.Services.AdresaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.AdresaAPI.Controllers
{
    [Route("api/drzava")]
    [ApiController]
    [Produces("application/json","application/xml")]
    public class DrzavaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDrzavaRepository _drzavaRepository;
        private readonly IMapper _mapper;

        public DrzavaController(IUnitOfWork unitOfWork, IDrzavaRepository drzavaRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _drzavaRepository = drzavaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Vraća sve države.
        /// </summary>
        /// <returns>Lista država.</returns>
        /// <response code="200">Vraća listu država</response>
        /// <response code="204">Nema podataka u bazi</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet]
        public async Task<IActionResult> GetDrzave()
        {
            try
            {
                var drzave = await _drzavaRepository.GetAll();

                if (drzave == null) return NoContent();

                var results = _mapper.Map<List<DrzavaDto>>(drzave);//mapiranje (iz) <u>

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Vraća jednu državu na osnovu ID-ja države.
        /// </summary>
        /// <param name="id">ID države</param>
        /// <returns>Jedna država.</returns>
        /// <response code="200">Vraća traženu državu</response>
        /// <response code="404">Nije pronađena nijedna država sa datim ID države</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="SuperUser, Menadzer, Admin, TehnickiSekretar")]
        [HttpGet("{id:guid}", Name = "GetDrzava")]
        public async Task<IActionResult> GetDrzava(Guid id)
        {
            try
            {
                var drzava = await _drzavaRepository.Get(id);

                if(drzava == null) return NotFound();

                var result = _mapper.Map<DrzavaDto>(drzava);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        /// <summary>
        /// Kreira novu državu.
        /// </summary>
        /// <param name="drzavaDTO">Model države</param>
        /// <returns>Potvrda o kreiranoj državi.</returns>
        /// <remarks>
        /// Primer zahteva za kreiranje nove države \
        /// POST /api/drzava \
        /// {     \
        ///     "drzavaNaziv": "Nemačka" \
        /// }
        /// </remarks>
        /// <response code="201">Vraća kreiranu državu</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, TehnickiSekretar, Operater")]
        [HttpPost]
        public async Task<IActionResult> CreateDrzava([FromBody] DrzavaCreateDto drzavaDTO)
        {
            
            try { 
                var drzava = _mapper.Map<Drzava>(drzavaDTO);

                drzava.DrzavaId = Guid.NewGuid();

                await _unitOfWork.Drzava.Insert(drzava);

                await _unitOfWork.Save();

                return CreatedAtRoute("GetDrzava", new { id = drzava.DrzavaId }, drzava);
            }
            catch (Exception ex )
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Insert error.");
            }
        }

        /// <summary>
        /// Ažurira jednu državu.
        /// </summary>
        /// <param name="drzavaDTO">Model države koja se ažurira</param>
        /// <returns>Potvrdu o modifikovanoj državi.</returns>
        /// <response code="200">Vraća ažuriranu državu</response>
        /// <response code="404">Država koja se ažurira nije pronađena</response>
        /// <response code="500">Serverska greška</response>
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, TehnickiSekretar, Operater")]
        [HttpPut]
        public async Task<IActionResult> UpdateDrzava([FromBody] DrzavaUpdateDto drzavaDTO)
        {
            try
            {
                var drzava = await _drzavaRepository.Get(drzavaDTO.DrzavaId);

                if(drzava == null) return NotFound();

                _mapper.Map(drzavaDTO, drzava);//mapira dto koji ima izmenjene info na entitet drzave

                _unitOfWork.Drzava.Update(drzava);

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
        /// Vrši brisanje jedne države na osnovu ID-ja države.
        /// </summary>
        /// <param name="id">ID države</param>
        /// <returns>Status 204 (NoContent)</returns>
        /// <response code="204">Država uspešno obrisana</response>
        /// <response code="404">Nije pronađena država za brisanje</response>
        /// <response code="500">Serverska greška</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //[Authorize(Roles="Admin, TehnickiSekretar, Operater")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteDrzava(Guid id)
        {
            try
            {
                var drzava = await _drzavaRepository.Get(id);

                if (drzava == null) return NotFound();

                await _unitOfWork.Drzava.Delete(id);

                await _unitOfWork.Save();

                return NoContent();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Delete error.");
            }
        }
    }
}
