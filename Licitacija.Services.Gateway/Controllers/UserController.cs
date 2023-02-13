using Licitacija.Services.Gateway.Dtos;
using Licitacija.Services.Gateway.Models;
using Licitacija.Services.Gateway.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitacija.Services.Gateway.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginInfo)
        {
            var response = await _userService.Login<UserDTO>(loginInfo);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {           
            var response = await _userService.Logout<string>();
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerInfo)
        {
            var response = await _userService.Register<string>(registerInfo);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest("Something went wrong!");
        }

    }
}
