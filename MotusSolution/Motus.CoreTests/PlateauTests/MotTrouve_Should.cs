using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Motus.Core;

namespace Motus.CoreTests.PlateauTests
{

    [TestClass()]
    public class MotTrouve_Should
    {
        [TestMethod()]
        public void ReturnFalse_IfNoTentatives()
        {
            Mock<ICalculMotService> calculMock = new Mock<ICalculMotService>();
            Plateau plateau = new Plateau(calculMock.Object);

            var actual = plateau.MotTrouve();

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void ReturnFalse_IfLastIsKo()
        {
            Mock<ICalculMotService> calculMock = new Mock<ICalculMotService>();
            Plateau plateau = new Plateau(calculMock.Object);
            plateau.Tentatives.Add(TestHelper.CreateInvalidMot("test1"));
            plateau.Tentatives.Add(TestHelper.CreateInvalidMot("test2"));

            var actual = plateau.MotTrouve();

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void ReturnTrue_IfLastIsOk()
        {
            Mock<ICalculMotService> calculMock = new Mock<ICalculMotService>();
            Plateau plateau = new Plateau(calculMock.Object);
            plateau.Tentatives.Add(TestHelper.CreateInvalidMot("test1"));
            plateau.Tentatives.Add(TestHelper.CreateValidMot("test2"));

            var actual = plateau.MotTrouve();

            Assert.IsTrue(actual);
        }
    }
}
