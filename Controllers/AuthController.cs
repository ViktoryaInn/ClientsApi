using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using ClientsApi.Models;
using ClientsApi.Schemas;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientsApi.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly ApiContext _context;

        public AuthController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login([FromBody] LoginInfo info)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == info.Login);
            
            if (user == null) return NotFound();

            await Authenticate(info.Login);

            return Ok();
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterInfo info)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == info.Login);
            
            if(user != null) return BadRequest();
            
            await _context.Users.AddAsync(info.Adapt<User>());
            await _context.SaveChangesAsync();
            
            await Authenticate(info.Login);

            return Ok();
        }

        [Route("logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, userName),
                new("login-time", DateTime.UtcNow.ToString(CultureInfo.InvariantCulture))
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                                        ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}