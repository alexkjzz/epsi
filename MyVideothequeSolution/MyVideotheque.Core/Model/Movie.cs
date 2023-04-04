using System.Text.Json.Serialization;

namespace MyVideotheque.Core.Model
{
    public class Movie
    {
        [JsonPropertyName("imdbID")]
        public string ID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
        public bool Watched { get; set; }
        public bool Watching { get; set; }
        [JsonPropertyName("imdbRating")]
        public string Rating { get; set; }
        public string Director { get; set; }
        public string Released { get; set; }
    }
}