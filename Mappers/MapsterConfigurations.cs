using Mapster;
using MyMovies.Api.Domain.Models;
using MyMovies.Api.DTOs;

namespace MyMovies.Api.Mappers
{
    public static class MapsterConfigurations
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            //Filmes
            TypeAdapterConfig<MovieAddDto, Movie>.NewConfig();
            TypeAdapterConfig<Movie, MovieAddDto>.NewConfig();
            TypeAdapterConfig<Movie, MovieGetDto>
                .NewConfig()
                .Map(dest => dest.Titulo, src => src.Title)
                .Map(dest => dest.Descricao, src => src.Description)
                .Map(dest => dest.Diretor, src => src.Director)
                .Map(dest => dest.Generos, src => src.Gender)
                .Map(dest => dest.Atores, src => src.Actors)
                .Map(dest => dest.AnoLancamento, src => src.Year);

            //Usuario
            TypeAdapterConfig<UserAddDto, User>.NewConfig();
            TypeAdapterConfig<User, UserAddDto>.NewConfig();
        }
    }
}