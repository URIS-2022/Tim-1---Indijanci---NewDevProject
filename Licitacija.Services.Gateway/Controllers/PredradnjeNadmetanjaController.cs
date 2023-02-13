using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PredradnjeNadmetanjaController : ControllerBase
    {
        private readonly IPredradnjaNadmetanja _predradnjaNadmetanja;

        public PredradnjeNadmetanjaController(IPredradnjaNadmetanja predradnjaNadmetanja)
        {
            _predradnjaNadmetanja = predradnjaNadmetanja;
        }

        [HttpGet]
        public async Task<IActionResult> GetPredradnjeNadmetanja()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _predradnjaNadmetanja.GetPredradnjaNadmetanja<List<PredradnjeNadmetanjaDto>>(token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPredradnjeNadmetanjaById(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _predradnjaNadmetanja.GetPredradnjaNadmetanjaById<PredradnjeNadmetanjaDto>(id, token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpGet("PredradnjeNadmetanjaOsnovneInformacije/{id:guid}")]
        public async Task<IActionResult> GetPredradnjeNadmetanjaOsnovneInformacije(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _predradnjaNadmetanja.GetPredradnjaNadmetanjaOsnovneInformacije<PredradnjeBasicInfoDto>(id, token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePredradnjeNadmetanja(PredradnjeNadmetanjaCreateDto predradnjeNadmetanjaDTO)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _predradnjaNadmetanja.CreatePredradnjaNadmetanja<string>(predradnjeNadmetanjaDTO, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePredradnjeNadmetanja(PredradnjeNadmetanjaUpdateDto predradnjeNadmetanjaDTO)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _predradnjaNadmetanja.UpdatePredradnjaNadmetanja<string>(predradnjeNadmetanjaDTO, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePredradnjeNadmetanja(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _predradnjaNadmetanja.DeletePredradnjaNadmetanja<string>(id, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }
    }
}
