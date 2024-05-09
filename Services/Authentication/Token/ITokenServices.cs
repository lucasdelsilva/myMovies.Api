using MyMovies.Api.Domain.Models;

namespace MyMovies.Api.Services.Authentication.Token
{
    public interface ITokenServices
    {
        string GenerateToken(User user);
    }
}
