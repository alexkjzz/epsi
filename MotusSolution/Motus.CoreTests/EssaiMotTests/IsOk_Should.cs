using Microsoft.VisualStudio.TestTools.UnitTesting;
using Motus.Core;

namespace Motus.CoreTests.EssaiMotTests
{
    [TestClass()]
    public class IsOk_Should
    {
        [TestMethod()]
        public void ReturnTrue_IfAllLettersOk()
        {
            EssaiMot essaiMot = TestHelper.CreateValidMot("test");

            var actual = essaiMot.IsOk();

            Assert.IsTrue(actual);
        }

        [TestMethod()]
        public void ReturnFalse_IfOneLetterKo()
        {
            EssaiMot essaiMot = TestHelper.CreateValidMot("test");
            essaiMot.Lettres.Add(new Lettre() { Caractere = 'c', Etat = EtatLettre.MauvaiseLettre });

            var actual = essaiMot.IsOk();

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void ReturnFalse_IfOneLetterMalPlace()
        {
            EssaiMot essaiMot = TestHelper.CreateValidMot("test");
            essaiMot.Lettres.Add(new Lettre() { Caractere = 'c', Etat = EtatLettre.BonneLettreMalPlacee });

            var actual = essaiMot.IsOk();

            Assert.IsFalse(actual);
        }
    }
}