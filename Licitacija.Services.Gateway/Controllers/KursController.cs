using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Services;
using Licitacija.Services.Gateway.Services.Implementation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.Gateway.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KursController : ControllerBase
    {
        private readonly IKursService _kursServis;

        public KursController(IKursService kursServis)
        {
            _kursServis = kursServis;
        }

        [HttpGet]
        public async Task<IActionResult> GetKurs()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _kursServis.GetKurs<List<KursDto>>(token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetKursById(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _kursServis.GetKursById<KursDto>(id, token);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPost]
        public async Task<IActionResult> CreateKurs(KursCreateDto kursDTO)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _kursServis.CreateKurs<string>(kursDTO, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateKurs(KursUpdateDto kursDTO)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _kursServis.UpdateKurs<string>(kursDTO, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteKurs(Guid id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _kursServis.DeleteKurs<string>(id, token);
            if (response != null)
            {
                return Ok();
            }
            return BadRequest("Something went wrong!");
        }
    }
}
