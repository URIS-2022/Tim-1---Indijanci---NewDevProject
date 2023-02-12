using IdentityModel;
using Licitacija.Services.Identity.DbContexts;
using Licitacija.Services.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Licitacija.Services.Identity.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManeger)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManeger;
        }

        public void Initialize()
        {
            if (_roleManager.FindByNameAsync(RoleEnum.Admin.ToString()).Result == null)
            {
                for (int i = 0; i < Enum.GetNames(typeof(RoleEnum)).Length; i++)
                {
                    _roleManager.CreateAsync(new IdentityRole(Enum.GetName(typeof(RoleEnum), i).ToString())).GetAwaiter().GetResult();
                }
            }
            else { return; }

            ApplicationUser adminUser = new()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "1111111111",
                FirstName = "Admin",
                LastName = "Initial"
            };

            _userManager.CreateAsync(adminUser, "Admin123*").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(adminUser, RoleEnum.Admin.ToString()).GetAwaiter().GetResult();

            var temp1 = _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, adminUser.FirstName + " " + adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName, adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName, adminUser.LastName),
                new Claim(JwtClaimTypes.Role, RoleEnum.Admin.ToString())
            }).Result;
        }
    }
}
