using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JWTPractice.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace JWTPractice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public TokenController(IConfiguration configuration, AppDbContext context )
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserInfo _userInfo)
        {
            if (_userInfo == null || _userInfo.UserName == null || _userInfo.Password == null)
            {
                return BadRequest();
            }

            var user = await _context.UserInfo.FirstOrDefaultAsync(u =>
                u.UserName == _userInfo.UserName && u.Password == _userInfo.Password);

            if (user == null)
            {
                return BadRequest(new {message = "Invalid Username or Password"});
            }

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["JWT:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                new Claim("Email", user.Email), 
            };

            var secretKey = Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]);
            var key = new SymmetricSecurityKey(secretKey);
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                _configuration["JWT:Issuer"],
                _configuration["JWT:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials:signIn
                );

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
