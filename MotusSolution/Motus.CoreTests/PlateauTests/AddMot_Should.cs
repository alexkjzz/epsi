using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Motus.Core;

namespace Motus.CoreTests.PlateauTests
{
    [TestClass()]
    public class AddMot_Should
    {
        [TestMethod]
        public void CalculMotOk_WhenAddMot()
        {
            Mock<ICalculMotService> calculMock = new Mock<ICalculMotService>();
            calculMock.Setup(c => c.CalculMot("test", "COUCOU")).Verifiable();
            Plateau plateau = new Plateau(calculMock.Object);
            plateau.MotADeviner = "COUCOU";

            plateau.AddMot("test");

            calculMock.Verify();
        }

        [TestMethod]
        public void AddTentative_WhenAddMot()
        {
            Mock<ICalculMotService> calculMock = new Mock<ICalculMotService>();
            var essaiMot = new EssaiMot();
            calculMock.Setup(c => c.CalculMot(It.IsAny<string>(), It.IsAny<string>())).Returns(essaiMot);
            Plateau plateau = new Plateau(calculMock.Object);

            plateau.AddMot("test");

            Assert.AreEqual(plateau.Tentatives.Last(), essaiMot);
        }


    }
}
