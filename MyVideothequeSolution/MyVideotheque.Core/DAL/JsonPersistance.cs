using MyVideotheque.Core.Model;
using System.Text.Json;

namespace MyVideotheque.Core.DAL
{
    public class JsonPersistance : IPersistance
    {
        private static string JSON_FILE_PATH = @"C:\Temp\epsi\MyVideothequeSolution\movies.json";

        public Movie[] LoadMovies()
        {
            List<Movie> movies = new List<Movie>();
            if (File.Exists(JSON_FILE_PATH))
            {
                movies.AddRange(JsonSerializer.Deserialize<Movie[]>(File.ReadAllText(JSON_FILE_PATH)));
            }
            return movies.ToArray();
        }

        public void SaveMovies(Movie[] movies)
        {
            File.WriteAllText(JSON_FILE_PATH, JsonSerializer.Serialize(movies.ToArray()));
        }
    }
}
