using CinemaAllStar.Application.Services.Movies;
using CinemaAllStar.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaAllStar.Movie.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet("listMovies")]
        public async Task<IActionResult> Index(string param, int? page)
        {
            List<Movies> filmes = new List<Movies>();

            filmes = await _moviesService.PegaListaGeral(param, page);

            return Ok(filmes);
        }

        [HttpGet("genders")]
        public async Task<IActionResult> ListGenders()
        {
            List<Genero> generos = new List<Genero>();

            generos = await _moviesService.PegaListaGeneros();

            return Ok(generos);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMovies(string query)
        {
            List<Movies> filmes = new List<Movies>();

            filmes = await _moviesService.BuscaFilme(query);

            return Ok(filmes);
        }

        [HttpGet("id")]
        public async Task<IActionResult> SearchMoviesById(int id)
        {
            Movies filmes = new Movies();

            filmes = await _moviesService.BuscaFilmeById(id);

            return Ok(filmes);
        }
    }
}
