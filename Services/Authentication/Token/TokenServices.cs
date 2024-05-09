﻿using Microsoft.IdentityModel.Tokens;
using MyMovies.Api.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyMovies.Api.Services.Authentication.Token
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _configuration;

        public TokenServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id),
                new Claim("dateOfBirth", user.Birthday),
                new Claim("loginDateAuthentication", DateTime.Now.ToShortDateString() + " - " +DateTime.Now.ToLongTimeString()),

            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetConnectionString("Token")));
            var signingCredentials = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(expires: DateTime.Now.AddMinutes(10), claims: claims, signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}