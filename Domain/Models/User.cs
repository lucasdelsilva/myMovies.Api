using Microsoft.AspNetCore.Identity;

namespace MyMovies.Api.Domain.Models
{
    public class User : IdentityUser
    {
        public string Birthday { get; set; }
        public User() : base() { }
    }
}