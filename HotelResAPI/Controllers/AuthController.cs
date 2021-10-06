using HotelResAPI.Data;
using HotelResAPI.Models;
using HotelResAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace HotelResAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly HotelResDbContext _context;

        public AuthController(HotelResDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginCreds loginCreds)
        {
            if (loginCreds == null)
                return BadRequest();

            try
            {
                User u = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginCreds.Email);

                string password = SecurityService.Hasher(loginCreds.Password, u.Salt);

                if(u.Password == password)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, SecurityService.Encrypt(AppSettingsSingleton.Instance.JwtEmailEncryption, u.UserId.ToString())),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettingsSingleton.Instance.JwtSecret));
                    var tokenCreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(string.Empty,
                        string.Empty,
                        claims,
                        expires: DateTime.Now.AddSeconds(15 * 60),
                        signingCredentials: tokenCreds);
                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
            }
            catch(Exception epicFail)
            {
                Debug.WriteLine(epicFail.Message);
                return BadRequest(epicFail.Message);
            }

            return Forbid();


        }


        
    }
}
