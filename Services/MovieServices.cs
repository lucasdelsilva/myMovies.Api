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

        public Task<bool> PutAsync(int id, MoviePutDto movieDto)
        {
            return _repository.Put(id, movieDto);
        }

        public Task<bool> RemoveAsync(int id)
        {
            return _repository.Remove(id);
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