using CinemaAllStar.Domain.Entities;
using CinemaAllStar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAllStar.Application.Services.Movies
{
    public class MoviesService : IMoviesService
    {
        private readonly IMoviesRepository _moviesRepository;

        public MoviesService(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public async Task<List<Domain.Entities.Movies>> BuscaFilme(string query)
        {
            return await _moviesRepository.SearchMovies(query);
        }

        public async Task<Domain.Entities.Movies> BuscaFilmeById(int movieId)
        {
            return await _moviesRepository.GetMovieById(movieId);
        }

        public async Task<List<Genero>> PegaListaGeneros()
        {
            return await _moviesRepository.GetListGenders();
        }

        public async Task<List<Domain.Entities.Movies>> PegaListaGeral(string param, int? page)
        {
            return await _moviesRepository.GetListMovies(param,page);
        }
    }
}
