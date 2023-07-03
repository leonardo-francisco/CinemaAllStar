using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CinemaAllStar.Domain.Entities
{
    public class Genero
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class GeneroResponse
    {

        [JsonPropertyName("genres")]
        public List<Genero> Results { get; set; }
    }
}
