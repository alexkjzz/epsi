using Epsilon.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epsilon.CoreTests.EleveTests
{
    [TestClass()]
    internal class AjouterNotes_Doit
    {
        [TestMethod()]
        public void Rien_SiPasDeNote()
        {
            var eleve = new Eleve();

            eleve.AjouterNotes();

            Assert.AreEqual(0, eleve.Notes.Count());
        }


        [TestMethod()]
        public void AjouterDesNotes_SiNotesEnParametre()
        {
            var eleve = new Eleve();

            eleve.AjouterNotes(15,16,13, 9.2m,12);

            Assert.AreEqual(5, eleve.Notes.Count());
            Assert.IsTrue(eleve.Notes.Contains(15));
            Assert.IsTrue(eleve.Notes.Contains(16));
            Assert.IsTrue(eleve.Notes.Contains(13));
            Assert.IsTrue(eleve.Notes.Contains(9.2m));
            Assert.IsTrue(eleve.Notes.Contains(12));
        }
    }
}
