using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BrunskerApi.DTO;
using BrunskerApi.Models;
using BrunskerApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BrunskerApi.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController:ControllerBase
    {
        private readonly IAuthServices _services;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthController(IAuthServices services, IConfiguration configuration, IMapper mapper)
        {
            _services = services;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegister userForRegister)
        {
            userForRegister.Nickname = userForRegister.Nickname.ToUpper();

            if( await _services.UserExists(userForRegister.Nickname))
            {
                return BadRequest("User already exists");
            }
            var user = _mapper.Map<User>(userForRegister);
            var createdUser = await _services.Register(user, userForRegister.Password);           

            return StatusCode(201);              
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login (UserForLogin userForLogin) {
            var userFromLogin = await _services.Login(userForLogin.Nickname.ToUpper (), userForLogin.Password);

            if (userFromLogin == null) {
                return Unauthorized ();
            } else {
                var claims = new [] {
                    new Claim (ClaimTypes.NameIdentifier, userFromLogin.Id.ToString ()),
                    new Claim (ClaimTypes.Name, userFromLogin.Nickname)
                };
                var key = new SymmetricSecurityKey (Encoding.UTF8
                                                    .GetBytes (_configuration.GetSection ("AppSettings:Token").Value));

                var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor {
                    Subject = new ClaimsIdentity (claims),
                    Expires = DateTime.Now.AddDays (1),
                    SigningCredentials = creds
                };

                var tokenHandler = new JwtSecurityTokenHandler ();

                var token = tokenHandler.CreateToken (tokenDescriptor);

                return Ok (new {
                    token = tokenHandler.WriteToken (token)
                });
            }
        }
    }
}