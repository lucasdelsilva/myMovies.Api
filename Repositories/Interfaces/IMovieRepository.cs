using MyMovies.Api.DTOs;

namespace MyMovies.Api.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<bool> Add(MovieAddDto movie);
        Task<bool> Put(int id, MoviePutDto movie);
        Task<bool> Remove(int id);
        Task<MovieGetDto> Get(int id);
        Task<List<MovieGetDto>> GetAll();
    }
}
