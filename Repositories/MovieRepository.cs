using Mapster;
using Microsoft.EntityFrameworkCore;
using MyMovies.Api.Context.Data;
using MyMovies.Api.Domain.Models;
using MyMovies.Api.DTOs;
using MyMovies.Api.Repositories.Interfaces;

namespace MyMovies.Api.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationContext _dbContext;
        public MovieRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Add(MovieAddDto movieDto)
        {
            var movieMap = movieDto.Adapt<Movie>();
            if (movieMap is not null)
            {
                await _dbContext.Movies.AddAsync(movieMap);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<MovieGetDto> Get(int id)
        {
            var movie = await _dbContext.Movies.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            var moviesMap = movie.Adapt<MovieGetDto>();

            if (moviesMap is not null)
                return moviesMap;

            return null;
        }

        public async Task<List<MovieGetDto>> GetAll()
        {
            var movies = await _dbContext.Movies.ToListAsync();
            var moviesMap = movies.Adapt<List<MovieGetDto>>();

            if (movies.Count > 0)
                return moviesMap;

            return null;
        }
    }
}
