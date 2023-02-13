using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.Gateway.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LicitacijaController : ControllerBase
    {
        private readonly ILicitacijaService _licitacijaService;

        public LicitacijaController(ILicitacijaService licitacijaService)
        {
            _licitacijaService = licitacijaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLicitacija()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _licitacijaService.GetLicitacija<List<LicitacijaDTO>>(token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetLicitacijaById(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _licitacijaService.GetLicitacijaById<LicitacijaDTO>(id, token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateLicitacija(LicitacijaCreateDTO licitacijaDTO)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _licitacijaService.CreateLicitacija<string>(licitacijaDTO, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLicitacija(LicitacijaUpdateDTO licitacijaDTO)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _licitacijaService.UpdateLicitacija<string>(licitacijaDTO, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteLicitacija(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _licitacijaService.DeleteLicitacija<string>(id, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }
    }
}
