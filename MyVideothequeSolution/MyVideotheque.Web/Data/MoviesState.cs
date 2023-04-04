using MyVideotheque.Core.Model;
using MyVideotheque.Core.Service;

namespace MyVideotheque.Web.Data
{
    public class MoviesState
    {
        public IVideothequeService _service;
        public event Action OnMoviesChange;
        public List<Movie> CachedMovies { get; set; }
        public MoviesState(IVideothequeService service)
        {
            _service = service;
            this.CachedMovies = new List<Movie>();
        }

        public void AddMovie(Movie movie)
        {
            this._service.AddMovie(movie);
            NotifyMoviesChanged();
        }

        public void RemoveMovie(Movie movie)
        {
            this._service.RemoveMovie(movie);
            NotifyMoviesChanged();
        }

        public void LoadMovies()
        {
            this.CachedMovies = this._service.GetMovies();
        }

        private void NotifyMoviesChanged() => OnMoviesChange?.Invoke();

    }
}
