using Epsilon.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epsilon.CoreTests.EleveTests
{
    [TestClass()]
    internal class CalculMoyenne_Doit
    {
        [TestMethod]
        public void Renvoyer0_SiPasDeNote()
        {
            var eleve = new Eleve();

            var actual = eleve.CalculMoyenne();

            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        public void RenvoyerNote_Si1Note()
        {
            var eleve = new Eleve();
            eleve.Notes.Add(9);

            var actual = eleve.CalculMoyenne();

            Assert.AreEqual(9, actual);
        }


        [TestMethod]
        public void RenvoyerMoyenne_SiNotes()
        {
            var eleve = new Eleve();
            eleve.Notes.Add(9);
            eleve.Notes.Add(12);
            eleve.Notes.Add(13.5m);
            eleve.Notes.Add(14);

            var actual = eleve.CalculMoyenne();

            Assert.AreEqual(12.125m, actual);
        }
    }
}
