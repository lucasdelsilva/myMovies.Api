
using MyMovies.Api.DTOs;

namespace MyMovies.Api.Services.Interfaces
{
    public interface IUserServices
    {
        Task<bool> AddAsync(UserAddDto userAddDto);
    }
}