using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BrunskerApi.DTO;
using BrunskerApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BrunskerApi.Controllers
{   
   // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserServices _services;
        private readonly IMapper _mapper;

        public UserController(IUserServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _services.GetAll();
            var userToList = _mapper.Map<IEnumerable<UserForList>>(users);
            return Ok(userToList);
        }
    }
}