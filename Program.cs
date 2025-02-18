using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyMovies.Api.Context.Data;
using MyMovies.Api.Domain.Models;
using MyMovies.Api.Mappers;
using MyMovies.Api.Repositories;
using MyMovies.Api.Repositories.Interfaces;
using MyMovies.Api.Services;
using MyMovies.Api.Services.Authentication;
using MyMovies.Api.Services.Authentication.Token;
using MyMovies.Api.Services.Interfaces;

internal class Program
{
    [Obsolete]
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigurationApplicationServices(builder);
        ConfigurationInterfaces(builder);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //builder.Services.AddSwaggerGen(config =>
        //{
        //    config.SwaggerDoc("v1", new OpenApiInfo { Title = "FilmesAPI", Version = "v1" });
        //    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        //    config.IncludeXmlComments(xmlPath);
        //});

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }

    private static void ConfigurationInterfaces(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthenticationServices, AuthenticationServices>();
        builder.Services.AddScoped<ITokenServices, TokenServices>();

        builder.Services.AddScoped<IMovieServices, MovieServices>();
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();

        builder.Services.AddScoped<IUserServices, UserServices>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }

    [Obsolete]
    private static void ConfigurationApplicationServices(WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<ApplicationContext>(options =>
                       options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionApplication")));

        builder.Services.AddControllers().AddFluentValidation(conf =>
        {
            conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
        });

        builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
        builder.Services.RegisterMaps();
    }
}