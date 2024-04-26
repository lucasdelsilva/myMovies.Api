using MyMovies.Api.DTOs;

namespace MyMovies.Api.Services.Interfaces
{
    public interface IMovieServices
    {
        Task<bool> AddAsync(MovieAddDto movieDto);
        Task<bool> PutAsync(int id, MoviePutDto movieDto);
        Task<bool> RemoveAsync(int id);
        Task<MovieGetDto> GetAsync(int id);
        Task<List<MovieGetDto>> GetAllAsync();
    }
}
