using MyMovies.Api.Domain.Models;
using MyMovies.Api.DTOs;
using MyMovies.Api.Repositories.Interfaces;
using MyMovies.Api.Services.Interfaces;

namespace MyMovies.Api.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IMovieRepository _repository;
        public MovieServices(IMovieRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> AddAsync(MovieAddDto movieDto)
        {
            return _repository.Add(movieDto);
        }

        public Task<List<MovieGetDto>> GetAllAsync()
        {
            return _repository.GetAll();
        }

        public Task<MovieGetDto> GetAsync(int id)
        {
            return _repository.Get(id);
        }
    }
}