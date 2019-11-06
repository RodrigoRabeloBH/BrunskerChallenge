using System.Threading.Tasks;
using AutoMapper;
using BrunskerApi.DTO;
using BrunskerApi.Models;
using BrunskerApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserForRegister userForRegister)
        {
            userForRegister.Nickname = userForRegister.Nickname.ToUpper();

            if( await _services.UserExists(userForRegister.Nickname))
            {
                return BadRequest("User already exists");
            }
            var user = _mapper.Map<User>(userForRegister);
            

            return StatusCode(201);
              
        }
    }
}