using Microsoft.EntityFrameworkCore;
using MyMovies.Api.Domain.Models;

namespace MyMovies.Api.Context.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> User { get; set; }
    }
}