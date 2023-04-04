using MyVideotheque.Core.Model;

namespace MyVideotheque.Core.Service
{
    public interface IMovieCatalogFinderService
    {
        Movie Get(string id);
        List<Movie> Search(string title);
    }
}