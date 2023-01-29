using AutoMapper;
using Licitacija.Services.KupacAPI.DTOs.KontaktOsobaDTOs;
using Licitacija.Services.KupacAPI.DTOs.PrioritetDTOs;
using Licitacija.Services.KupacAPI.Entities;
using Licitacija.Services.KupacAPI.Repositories.ConcreteClasses;
using Licitacija.Services.KupacAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.KupacAPI.Controllers
{
    [ApiController]
    [Route("api/kontaktOsoba")]
    public class KontaktOsobaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKontaktOsobaRepository _kontaktOsobaRepository;
        private readonly IMapper _mapper;

        public KontaktOsobaController(IUnitOfWork unitOfWork, IKontaktOsobaRepository kontaktOsobaRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _kontaktOsobaRepository = kontaktOsobaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetKontaktOsobe()
        {
            try
            {
                var kOsobe = await _kontaktOsobaRepository.GetAll();

                if (kOsobe == null) return NoContent();

                var results = _mapper.Map<List<KontaktOsobaDTO>>(kOsobe);

                return Ok(results);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id:guid}", Name = "GetKontaktOsoba")]
        public async Task<IActionResult> GetKontaktOsoba(Guid id)
        {
            try
            {
                var kOsoba = await _kontaktOsobaRepository.Get(id);

                if (kOsoba == null) return NotFound();

                var result = _mapper.Map<KontaktOsobaDTO>(kOsoba);

                return Ok(result);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateKontaktOsoba([FromBody] KontaktOsobaCreateDTO kOsobaDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var kOsoba = _mapper.Map<KontaktOsoba>(kOsobaDTO);

                kOsoba.KontaktOsobaId = Guid.NewGuid();

                await _unitOfWork.KontaktOsoba.Insert(kOsoba);

                await _unitOfWork.Save();

                return CreatedAtRoute("GetKontaktOsoba", new { id = kOsoba.KontaktOsobaId }, kOsoba);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Insert error.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateKontaktOsoba([FromBody] KontaktOsobaUpdateDTO kOsobaDTO)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var kOsoba = await _kontaktOsobaRepository.Get(kOsobaDTO.KontaktOsobaId);

                if (kOsoba == null) return NotFound();

                _mapper.Map(kOsobaDTO, kOsoba);

                _unitOfWork.KontaktOsoba.Update(kOsoba);

                await _unitOfWork.Save();

                return Ok();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

                return StatusCode(500, "Update error.");
            }
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteKontaktOsoba(Guid id)
        {
            try
            {
                var kOsoba = await _kontaktOsobaRepository.Get(id);

                if (kOsoba == null) return NotFound();

                await _unitOfWork.KontaktOsoba.Delete(id);

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
