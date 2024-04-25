using MyMovies.Api.DTOs;

namespace MyMovies.Api.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<bool> Add(MovieAddDto movie);
        Task<MovieGetDto> Get(int id);
        Task<List<MovieGetDto>> GetAll();
    }
}
