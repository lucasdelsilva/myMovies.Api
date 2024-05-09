using Microsoft.AspNetCore.Mvc;
using MyMovies.Api.DTOs;
using MyMovies.Api.Repositories.Interfaces;

namespace MyMovies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // POST api/<AutenticationUser>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserAddDto userAddDto)
        {
            var result = await _userRepository.Add(userAddDto);
            if (result)
                return Ok(result);

            return BadRequest();
        }
    }
}