using MyMovies.Api.DTOs;

namespace MyMovies.Api.Services.Authentication
{
    public interface IAuthenticationServices
    {
        Task<string> LoginAsync(AuthenticationDto authentication);
    }
}