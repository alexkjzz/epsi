using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motus.Core;

namespace Motus.CoreTests.CalculMotServiceTests
{
    [TestClass]
    public class CalculMot_Should
    {
        [TestMethod]
        public void SplitLetter_WhenCalcul()
        {
            CalculMotService service = new CalculMotService();

            var actual = service.CalculMot("ABC", "XXX");

            Assert.AreEqual('A', actual.Lettres[0].Caractere);
            Assert.AreEqual('B', actual.Lettres[1].Caractere);
            Assert.AreEqual('C', actual.Lettres[2].Caractere);
        }

        [TestMethod]
        public void CalculEtatLettre_WhenCalcul()
        {
            CalculMotService service = new CalculMotService();

            var actual = service.CalculMot("ABC", "XBA");

            Assert.AreEqual(EtatLettre.BonneLettreMalPlacee, actual.Lettres[0].Etat);
            Assert.AreEqual(EtatLettre.OK, actual.Lettres[1].Etat);
            Assert.AreEqual(EtatLettre.MauvaiseLettre, actual.Lettres[2].Etat);
        }


        [TestMethod]
        public void ReturnOk_WhenSameWord()
        {
            CalculMotService service = new CalculMotService();

            var actual = service.CalculMot("test", "test");

            Assert.IsTrue(actual.IsOk());
        }
    }
}
