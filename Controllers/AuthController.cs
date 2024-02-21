using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using SaudePlus.Models;

namespace SaudePlus.Controllers
{
    [Route("api/auth")]
    [ApiController]

    public class AuthController : ControllerBase {
        private IConfiguration _config;
        public AuthController(IConfiguration config) 
        {
            _config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthRequest request) {
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequest request) {
            return Ok(generateJwtToken());
        }

        private string generateJwtToken() {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            var token =  new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return token;
        }
    }
}