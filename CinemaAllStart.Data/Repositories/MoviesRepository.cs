using CinemaAllStar.Domain.Entities;
using CinemaAllStar.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CinemaAllStar.Data.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration configuration;

        public MoviesRepository(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            configuration = config;
        }

        public async Task<List<Genero>> GetListGenders()
        {
            var tokenApi = configuration.GetSection("TMDBAPI:token");
            var baseAddress = configuration.GetSection("TMDBAPI:baseAddress");

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenApi.Value);
            client.BaseAddress = new Uri(baseAddress.Value);

            var url = $"genre/movie/list?language=pt-br";

            var result = new List<Genero>();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                var generoResponse = System.Text.Json.JsonSerializer.Deserialize<GeneroResponse>(stringResponse);
                if (generoResponse != null && generoResponse.Results != null)
                {
                    result = generoResponse.Results;
                }
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }

        /// <summary>
        /// Aceita now_playing / popular / upcoming / top_rated
        /// </summary>
        /// <returns></returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<List<Movies>> GetListMovies(string param, int? page)
        {
            var tokenApi = configuration.GetSection("TMDBAPI:token");
            var baseAddress = configuration.GetSection("TMDBAPI:baseAddress");

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenApi.Value);
            client.BaseAddress = new Uri(baseAddress.Value);

            var url = $"movie/{param}?language=pt-br&page={page}";

            var result = new List<Movies>();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                var moviesResponse = System.Text.Json.JsonSerializer.Deserialize<MoviesResponse>(stringResponse);
                if (moviesResponse != null && moviesResponse.Results != null)
                {
                    result = moviesResponse.Results;
                }
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }

        public async Task<Movies> GetMovieById(int movieId)
        {
            var tokenApi = configuration.GetSection("TMDBAPI:token");
            var baseAddress = configuration.GetSection("TMDBAPI:baseAddress");

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenApi.Value);
            client.BaseAddress = new Uri(baseAddress.Value);

            var url = $"movie/{movieId}?language=pt-br";

            var result = new Movies();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                var moviesResponse = System.Text.Json.JsonSerializer.Deserialize<Movies>(stringResponse);
                if (moviesResponse != null)
                {
                    result = moviesResponse;
                }
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }

        public async Task<List<Movies>> SearchMovies(string query)
        {
            var tokenApi = configuration.GetSection("TMDBAPI:token");
            var baseAddress = configuration.GetSection("TMDBAPI:baseAddress");

            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenApi.Value);
            client.BaseAddress = new Uri(baseAddress.Value);

            var url = $"search/movie?query={query}&include_adult=false&language=pt-br&page=1";

            var result = new List<Movies>();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();

                var moviesResponse = System.Text.Json.JsonSerializer.Deserialize<MoviesResponse>(stringResponse);
                if (moviesResponse != null && moviesResponse.Results != null)
                {
                    result = moviesResponse.Results;
                }
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return result;
        }
    }
}
