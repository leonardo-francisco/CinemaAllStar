using CinemaAllStar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAllStar.Domain.Interfaces
{
    public interface IMoviesRepository
    {
        Task<List<Movies>> GetListMovies(string param, int? page);
        Task<List<Genero>> GetListGenders();
        Task<List<Movies>> SearchMovies(string query);
        Task<Movies> GetMovieById(int movieId);

    }
}
