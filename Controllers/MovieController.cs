using Microsoft.AspNetCore.Mvc;
using MyMovies.Api.DTOs;
using MyMovies.Api.Services.Interfaces;


namespace MyMovies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieServices _movieServices;
        public MovieController(IMovieServices movieServices)
        {
            _movieServices = movieServices;
        }

        // GET: api/<MovieController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _movieServices.GetAllAsync();
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _movieServices.GetAsync(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        // POST api/<MovieController>
        [HttpPost]
        public async Task<IActionResult> AdddMovie([FromBody] MovieAddDto movieDto)
        {
            var result = await _movieServices.AddAsync(movieDto);
            if (result)
                return Ok(result);

            return BadRequest();
        }

        // DELETE api/<MovieController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        //// PUT api/<MovieController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

    }
}
