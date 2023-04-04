using MyVideotheque.Core.Model;

namespace MyVideotheque.Core.DAL
{
    public interface IPersistance
    {
        Movie[] LoadMovies();
        void SaveMovies(Movie[] movies);
    }
}