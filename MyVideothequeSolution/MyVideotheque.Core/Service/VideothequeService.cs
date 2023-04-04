using MyVideotheque.Core.DAL;
using MyVideotheque.Core.Model;

namespace MyVideotheque.Core.Service
{
    public class VideothequeService : IVideothequeService
    {
        private List<Movie> _movies = null;
        private readonly IMovieCatalogFinderService _catalog;
        private readonly IPersistance _persistance;

        public VideothequeService(IMovieCatalogFinderService catalog, IPersistance persistance)
        {
            this._catalog = catalog;
            this._persistance = persistance;

            this._movies = new List<Movie>();
            this._movies.AddRange(this._persistance.LoadMovies());
        }

        public void AddMovieById(string id)
        {
            var movie = _catalog.Get(id);
            this.AddMovie(movie);
        }


        public void AddMovie(Movie movie)
        {
            this._movies.Add(movie);
            this._persistance.SaveMovies(this._movies.ToArray());
        }

        public List<Movie> GetMovies()
        {
            return this._movies;
        }

    }
}