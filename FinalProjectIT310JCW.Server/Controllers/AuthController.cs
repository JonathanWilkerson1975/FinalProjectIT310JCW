//using Microsoft.AspNetCore.Mvc;

//namespace FinalProjectIT310JCW.Server.Controllers
//{
//    public class AuthController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}

// AuthController.cs - ASP.NET Core Authentication API

using System;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace FinalProjectIT310JCW.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Email == "test@example.com" && model.Password == "password") // Simulated authentication
            {
                var tokenString = GenerateJWT(model.Email);
                return Ok(new { token = tokenString });
            }
            return Unauthorized("Invalid credentials");
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] SignupModel model)
        {
            // Normally, you’d save the user to the database here
            return Ok("User registered successfully");
        }

        private string GenerateJWT(string email)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignupModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

