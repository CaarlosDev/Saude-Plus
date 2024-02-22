using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using SaudePlus.Models;
using SaudePlus.Repositories.Interfaces;
using System.Net.Mail;

namespace SaudePlus.Controllers
{
    [Route("api/auth")]
    [ApiController]

    public class AuthController : ControllerBase {
        private IConfiguration _config;
        private IUserRepository _userRepository;
        public AuthController(IConfiguration config, IUserRepository userRepository) 
        {
            _config = config;
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthRequest request) {
            if (!validateEmail(request.Email)) {
                throw new Exception("Please provide a valid email address.");
            }
            
            var userExists = await _userRepository.GetUserByEmail(request.Email);
            if (userExists != null) {
                throw new Exception("This email is already in use.");
            }

            UserModel user = new UserModel();
            user.Email = request.Email;
            user.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
            
            UserModel createdUser = await _userRepository.CreateUser(user);
            string token = generateJwtToken();

            return Ok(new { createdUser, token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequest request) {
            if (!validateEmail(request.Email)) {
                throw new Exception("Please provide a valid email address.");
            }

            UserModel user = await _userRepository.GetUserByEmail(request.Email) ?? throw new Exception("This email is not registered");

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password)) {
                throw new Exception("Incorrect password.");
            }

            string token = generateJwtToken();

            return Ok(new { user, token });
        }

        private string generateJwtToken() {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var Sectoken = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddYears(1),
              signingCredentials: credentials);

            var token =  new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return token;
        }

        private bool validateEmail(string email)
        {
            try {
                var emailAddress = new MailAddress(email);
                return true;
            } catch {
                return false;
            }
        }
    }
}