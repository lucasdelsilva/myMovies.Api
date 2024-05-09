using MyMovies.Api.DTOs;
using MyMovies.Api.Repositories.Interfaces;
using MyMovies.Api.Services.Interfaces;

namespace MyMovies.Api.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository; ;
        }

        public Task<bool> AddAsync(UserAddDto userAddDto)
        {
            return _userRepository.Add(userAddDto);
        }
    }
}