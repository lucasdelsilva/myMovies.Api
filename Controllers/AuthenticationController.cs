using Microsoft.AspNetCore.Mvc;
using MyMovies.Api.DTOs;
using MyMovies.Api.Services.Authentication;

namespace MyMovies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationService;
        public AuthenticationController(IAuthenticationServices authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthenticationDto authentication)
        {
            var token = await _authenticationService.LoginAsync(authentication);
            return Ok(token);
        }
    }
}