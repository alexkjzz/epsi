using MyVideotheque.Core.Exception;
using MyVideotheque.Core.Model;
using System.Net.Http.Headers;

namespace MyVideotheque.Core.Service
{

    public class MovieCatalogFinderService : IMovieCatalogFinderService
    {
        private static string OMDP_API_KEY = "e578d967";

        private class OmdbApiResponse
        {
            public Movie[] Search { get; set; }
            public string totalResults { get; set; }
            public string Response { get; set; }
        }

        private class OmdbApiResponseError
        {
            public bool Reponse { get; set; }
            public string Error { get; set; }
        }

        public List<Movie> Search(string title)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                string url = "https://www.omdbapi.com/?apikey=" + OMDP_API_KEY + "+&p=1&s=" + title.Trim().Replace(' ', '+');
                var response = client.GetStringAsync(url).Result;

                var result = System.Text.Json.JsonSerializer.Deserialize<OmdbApiResponse>(response);
                return result.Search.ToList();
            }
        }

        public Movie Get(string id)
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                var response = client.GetStringAsync("https://www.omdbapi.com/?apikey=" + OMDP_API_KEY + "&i=" + id).Result;

                var result = System.Text.Json.JsonSerializer.Deserialize<Movie>(response);

                if (string.IsNullOrEmpty(result.ID))
                {
                    var errorResponse = System.Text.Json.JsonSerializer.Deserialize<OmdbApiResponseError>(response);
                    throw new InvalidMovieIdException(id, errorResponse.Error);
                }

                return result;
            }
        }


        /*
         * Exemple de JSON représentant un film
         * 
         * {
       "Title":"Modern Family",
       "Year":"2009–2020",
       "Rated":"TV-PG",
       "Released":"23 Sep 2009",
       "Runtime":"22 min",
       "Genre":"Comedy, Drama, Romance",
       "Director":"N/A",
       "Writer":"Steven Levitan, Christopher Lloyd",
       "Actors":"Ed O'Neill, Sofía Vergara, Julie Bowen, Ty Burrell",
       "Plot":"Three different but related families face trials and tribulations in their own uniquely comedic ways.",
       "Language":"English",
       "Country":"USA",
       "Awards":"Won 1 Golden Globe. Another 117 wins & 381 nominations.",
       "Poster":"https://m.media-amazon.com/images/M/MV5BNzRhNWIxYTEtYjc2NS00YWFlLWFhOGEtMDZiMWM1M2RkNDkyXkEyXkFqcGdeQXVyNjc0MjkzNjc@._V1_SX300.jpg",
       "Ratings":[
          {
             "Source":"Internet Movie Database",
             "Value":"8.4/10"
          }
       ],
       "Metascore":"N/A",
       "imdbRating":"8.4",
       "imdbVotes":"343,950",
       "imdbID":"tt1442437",
       "Type":"series",
       "totalSeasons":"11",
       "Response":"True"
    }*/
    }
}
