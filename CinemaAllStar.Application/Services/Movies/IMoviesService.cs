using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaAllStar.Domain.Entities;

namespace CinemaAllStar.Application.Services.Movies
{
    public interface IMoviesService
    {
        Task<List<CinemaAllStar.Domain.Entities.Movies>> PegaListaGeral(string param, int? page);
        Task<List<Genero>> PegaListaGeneros();
        Task<List<CinemaAllStar.Domain.Entities.Movies>> BuscaFilme(string query);
        Task<CinemaAllStar.Domain.Entities.Movies> BuscaFilmeById(int movieId);

    }
}
