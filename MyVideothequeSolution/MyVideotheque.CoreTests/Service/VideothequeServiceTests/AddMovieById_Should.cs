using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyVideotheque.Core.DAL;
using MyVideotheque.Core.Exception;
using MyVideotheque.Core.Model;
using MyVideotheque.Core.Service;

namespace MyVideotheque.CoreTests.Service.VideothequeServiceTests
{


    [TestClass()]
    public class AddMovieById_Should
    {
        [TestMethod()]
        [ExpectedException(typeof(InvalidMovieIdException))]
        public void GetMoviesTest()
        {
            var catalogFinderMock = new Mock<IMovieCatalogFinderService>();
            catalogFinderMock.Setup(c => c.Get(It.IsAny<string>())).Returns(new Movie());
            var persistanceMock = new Mock<IPersistance>();
            VideothequeService service = new VideothequeService(catalogFinderMock.Object, persistanceMock.Object);

            service.AddMovieById("badId");

            Assert.Fail("On ne doit pas arriver ici !");
        }


        [TestMethod()]
        public void CallSave_WhenOk()
        {
            var catalogFinderMock = new Mock<IMovieCatalogFinderService>();
            catalogFinderMock.Setup(c => c.Get(It.IsAny<string>())).Returns(new Movie() { Title = "some movie" });

            var persistanceMock = new Mock<IPersistance>();
            persistanceMock.Setup(p => p.SaveMovies(It.IsAny<Movie[]>())).Verifiable();
            VideothequeService service = new VideothequeService(catalogFinderMock.Object, persistanceMock.Object);

            service.AddMovieById("Id1");

            persistanceMock.Verify();

            Assert.Fail("On ne doit pas arriver ici !");
        }
    }
}