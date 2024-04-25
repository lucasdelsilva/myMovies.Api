using MyMovies.Api.DTOs;

namespace MyMovies.Api.Services.Interfaces
{
    public interface IMovieServices
    {
        Task<bool> AddAsync(MovieAddDto movieDto);
        Task<MovieGetDto> GetAsync(int id);
        Task<List<MovieGetDto>> GetAllAsync();
    }
}
