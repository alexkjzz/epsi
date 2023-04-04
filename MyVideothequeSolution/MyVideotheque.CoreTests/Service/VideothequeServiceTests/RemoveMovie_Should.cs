using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyVideotheque.Core.DAL;
using MyVideotheque.Core.Model;
using MyVideotheque.Core.Service;

namespace MyVideotheque.CoreTests.Service.VideothequeServiceTests
{
    [TestClass()]
    public class RemoveMovie_Should
    {
        [TestMethod]
        public void CallPersistanceSave_WhenRemoveMovie()
        {
            //Given
            var persistanceMock = new Mock<IPersistance>();
            var catalogMock = new Mock<IMovieCatalogFinderService>();

            persistanceMock.Setup(p => p.SaveMovies(It.IsAny<Movie[]>())).Verifiable();

            VideothequeService service = new VideothequeService(catalogMock.Object, persistanceMock.Object);

            Movie film1 = new Movie() {  Title = "Film1" };
            Movie film2 = new Movie() { Title = "Film2" };
            catalogMock.Setup(c => c.Get("1")).Returns(film1);
            catalogMock.Setup(c => c.Get("2")).Returns(film2);

            service.AddMovieById("1");
            service.AddMovieById("2");

            //Action
            service.RemoveMovie(film1);

            //Assert
            var movies = service.GetMovies();
            Assert.AreEqual(1, movies.Count);
            Assert.AreEqual("Film2", movies[0].Title);
            persistanceMock.Verify(p => p.SaveMovies(It.IsAny<Movie[]>()), Times.Exactly(3));
        }
    }
}