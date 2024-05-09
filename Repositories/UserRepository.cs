using Mapster;
using Microsoft.AspNetCore.Identity;
using MyMovies.Api.Context.Data;
using MyMovies.Api.Domain.Models;
using MyMovies.Api.DTOs;
using MyMovies.Api.Repositories.Interfaces;

namespace MyMovies.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _dbContext;
        private readonly UserManager<User> _userManager;
        public UserRepository(ApplicationContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<bool> Add(UserAddDto user)
        {
            var userMap = user.Adapt<User>();
            if (userMap is not null)
            {
                var result = await _userManager.CreateAsync(userMap, user.Password);
                if (result.Succeeded)
                    return true;
            }
            return false;
        }
    }
}
