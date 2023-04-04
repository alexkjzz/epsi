using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyVideotheque.Core.DAL;
using MyVideotheque.Core.Model;
using MyVideotheque.Core.Service;

namespace MyVideotheque.CoreTests.Service.VideothequeServiceTests
{
    [TestClass()]
    public class GetMovies_Should
    {
        [TestMethod()]
        public void Load2Movies_WhenPersistanceGive2Movies()
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie() { Title = "Movie 1" },
                new Movie() { Title = "Movie 2" }
            };

            var catalogFinderMock = new Mock<IMovieCatalogFinderService>();

            var persistanceMock = new Mock<IPersistance>();
            persistanceMock.Setup(p => p.LoadMovies()).Returns(movies.ToArray());

            VideothequeService service = new VideothequeService(catalogFinderMock.Object, persistanceMock.Object);

            var actual = service.GetMovies();
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(actual.Exists(m => m.Title == "Movie 1"));
        }
    }
}