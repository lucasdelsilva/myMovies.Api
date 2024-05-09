using MyMovies.Api.DTOs;

namespace MyMovies.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Add(UserAddDto user);
    }
}
