using Microsoft.EntityFrameworkCore;
using MyMovies.Api.Domain.Models;

namespace MyMovies.Api.Context.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Movie> Filmes { get; set; }
    }
}
