using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Api.DTOs;
using MyMovies.Api.Services.Interfaces;

#pragma warning disable 1591
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
        /// <summary>
        /// Lista todos os filme disponiveis.
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a listagem seja efetuado com sucesso.</response>
        /// <response code="404">Caso não encontre os filmes.</response>
        // GET: api/<MovieController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _movieServices.GetAllAsync();
            if (result is not null)
                return Ok(result);

            return NotFound();
        }

        /// <summary>
        /// Busca um filme pelo Id.
        /// </summary>
        /// <param name="id">Objeto de request</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso o retorno do filme seja efetuado com sucesso.</response>
        /// <response code="404">Caso não encontre o filme.</response>
        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _movieServices.GetAsync(id);
            if (result is not null)
                return Ok(result);

            return NotFound();
        }

        /// <summary>
        /// Adiciona um filme.
        /// </summary>
        /// <param name="movieDto">Objeto de request</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso seja adicionado com Sucesso.</response>
        /// <response code="400">Caso ocorra algum erro.</response>
        // POST api/<MovieController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AdddMovie([FromBody] MovieAddDto movieDto)
        {
            var result = await _movieServices.AddAsync(movieDto);
            if (result)
                return Ok(result);

            return BadRequest();
        }

        /// <summary>
        /// Atualiza os dados do filme pelo Id.
        /// </summary>
        /// <param name="id">Objeto de request identificador</param>
        /// <param name="moviePutDto">Objeto de request modelo de ajustes</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a atualização seja efetuado com sucesso.</response>
        /// <response code="404">Caso não encontre o filme.</response>
        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MoviePutDto moviePutDto)
        {
            var result = await _movieServices.PutAsync(id, moviePutDto);
            if (result)
                return Ok(result);

            return NotFound();
        }

        /// <summary>
        /// Deleta o filme pelo Id.
        /// </summary>
        /// <param name="id">Objeto de request</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso o delete seja efetuado com sucesso.</response>
        /// <response code="400">Caso de erro ao deletar o filme.</response>
        //DELETE api/<MovieController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _movieServices.RemoveAsync(id);
            if (result)
                return Ok(result);

            return BadRequest();
        }
    }
}