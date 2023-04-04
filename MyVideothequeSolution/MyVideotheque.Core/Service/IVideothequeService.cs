using MyVideotheque.Core.Model;

namespace MyVideotheque.Core.Service
{
    public interface IVideothequeService
    {
        List<Movie> GetMovies();
        void AddMovieById(string id);
        void AddMovie(Movie movie);
        void RemoveMovie(Movie movie);
    }
}