using Duende.IdentityServer.Events;
using Duende.IdentityServer.Extensions;
using IdentityModel;
using Licitacija.Services.Identity.Dtos;
using Licitacija.Services.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Licitacija.Services.Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO userLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(userLogin.Username, userLogin.Password, false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userLogin.Username);
                return Ok(user);
            }

            return BadRequest("Invalid credentials");
        }

        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                await _signInManager.SignOutAsync();
                return Ok("Signed out.");
            }

            return BadRequest("Not signed in!");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO userRegister)
        {
            var user = new ApplicationUser
            {
                UserName = userRegister.Username,
                Email = userRegister.Email,
                EmailConfirmed = true,
                FirstName = userRegister.FirstName,
                LastName = userRegister.LastName
            };

            var result = await _userManager.CreateAsync(user, userRegister.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userRegister.RoleName.ToString());

                await _userManager.AddClaimsAsync(user, new Claim[]{
                            new Claim(JwtClaimTypes.Name, userRegister.Username),
                            new Claim(JwtClaimTypes.Email, userRegister.Email),
                            new Claim(JwtClaimTypes.FamilyName, userRegister.LastName),
                            new Claim(JwtClaimTypes.GivenName, userRegister.FirstName),
                            new Claim(JwtClaimTypes.Role,userRegister.RoleName.ToString()) });

                await _signInManager.PasswordSignInAsync(userRegister.Username, userRegister.Password, false, lockoutOnFailure: true);

                return StatusCode(201,"Registred and logged in.");
            }

            return BadRequest("Something went wrong!");
        }

        [HttpGet("AccessDenied")]
        public async Task<IActionResult> AccessDenied()
        {
            return StatusCode(403, "Not authorized!");
        }
    }
}
