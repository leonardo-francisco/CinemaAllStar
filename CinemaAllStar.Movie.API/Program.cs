using CinemaAllStar.Application.Services.Movies;
using CinemaAllStar.Data.Repositories;
using CinemaAllStar.Domain.Interfaces;

namespace CinemaAllStar.Movie.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddHttpClient();

            //Adding Services
            builder.Services.AddScoped<IMoviesService, MoviesService>();

            //Adding Repositories
            builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
    }
}