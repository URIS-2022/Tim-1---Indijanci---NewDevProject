using AutoMapper;
using Licitacija.Services.KupacAPI.DTOs.FizickoLiceDTOs;
using Licitacija.Services.KupacAPI.DTOs.KontaktOsobaDTOs;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.KupacAPI.Controllers
{
    [ApiController]
    [Route("api/fizickoLice")]
    [Produces("application/json", "application/xml")]
    public class FizickoLiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FizickoLiceController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]   
        public async Task<IActionResult> GetFizickaLica()
        {
            try
            {
                var fLica = await _unitOfWork.FizickoLice.GetAll();

                if (fLica == null) return NoContent();

                var results = _mapper.Map<List<FizickoLiceDTO>>(fLica);

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id:guid}", Name = "GetFizickoLice")]
        public async Task<IActionResult> GetFizickoLice(Guid id)
        {
            try
            {
                var fLice = await _unitOfWork.FizickoLice.Get(i => i.FizickoLiceId == id);

                if (fLice == null) return NotFound();

                var result = _mapper.Map<FizickoLiceDTO>(fLice);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> CreateFizickoLice([FromBody] FizickoLiceCreateDTO fLiceDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var fLice = _mapper.Map<FizickoLice>(fLiceDTO);

                fLice.FizickoLiceId = Guid.NewGuid();

                await _unitOfWork.FizickoLice.Insert(fLice);

                await _unitOfWork.Save();

                return CreatedAtRoute("GetFizickoLice", new { id = fLice.FizickoLiceId }, fLice);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Insert error.");
            }
        }

        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut]
        public async Task<IActionResult> UpdateFizickoLice([FromBody] FizickoLiceUpdateDTO fLiceDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var fLice = await _unitOfWork.FizickoLice.Get(i => i.FizickoLiceId == fLiceDTO.FizickoLiceId);

                if (fLice == null) return NotFound();

                _mapper.Map(fLiceDTO, fLice);

                _unitOfWork.FizickoLice.Update(fLice);

                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Update error.");
            }
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteFizickoLice(Guid id)
        {
            try
            {
                var fLice = await _unitOfWork.FizickoLice.Get(i => i.FizickoLiceId == id);

                if (fLice == null) return NotFound();

                await _unitOfWork.FizickoLice.Delete(id);

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
