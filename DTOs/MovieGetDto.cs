using System.Text.Json.Serialization;

namespace MyMovies.Api.DTOs
{
    public class MovieGetDto
    {
        [JsonPropertyName("Título")]
        public string Titulo { get; set; }
        [JsonPropertyName("Descrição")]
        public string Descricao { get; set; }

        [JsonPropertyName("Diretor")]
        public string Diretor { get; set; }
        [JsonPropertyName("Gênero")]
        public List<string> Generos { get; set; }

        [JsonPropertyName("Atores")]
        public List<string> Atores { get; set; }
        [JsonPropertyName("Ano de lançamento")]
        public string AnoLancamento { get; set; }
    }
}