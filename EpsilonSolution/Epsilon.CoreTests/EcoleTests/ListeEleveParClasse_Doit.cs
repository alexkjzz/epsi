using Epsilon.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epsilon.CoreTests.EcoleTests
{
    [TestClass()]
    internal class ListeEleveParClasse_Doit
    {

        [TestMethod()]
        public void RenvoyerListVide_WhenLaClasseNExistePas()
        {
            //Givin
            Ecole epsi = new Ecole();
            epsi.Classes.Add(new Classe() { Nom = "SN1" });
            epsi.Classes.First().Eleves.Add(new Eleve() { Nom = "Mudas", Prenom = "Albert" });

            //When
            var actual = epsi.ListeEleveParClasse("SN3");

            //Then
            Assert.AreEqual(0, actual.Count());
        }

        [TestMethod()]
        public void RenvoyerLesElevesDeLaClass_WhenLaClasseExiste()
        {
            //Givin
            Ecole epsi = new Ecole();
            var sn1 = new Classe() { Nom = "SN1" };
            epsi.Classes.Add(sn1);
            sn1.Eleves.Add(new Eleve() { Nom = "Mudas", Prenom = "Albert" });
            sn1.Eleves.Add(new Eleve() { Nom = "Terrieur", Prenom = "Alain" });
            var sn6 = new Classe() { Nom = "SN6" };
            sn6.Eleves.Add(new Eleve() { Nom = "White", Prenom = "Walter" });
            sn6.Eleves.Add(new Eleve() { Nom = "Pinkman", Prenom = "Jessy" });
            sn6.Eleves.Add(new Eleve() { Nom = "White", Prenom = "Skyler" });

            //When
            var actualEleveParClasse = epsi.ListeEleveParClasse("SN1");

            //Then
            Assert.AreEqual(2, actualEleveParClasse.Count());
            Assert.IsNotNull(actualEleveParClasse.ToList().Find(e => e.Nom == "Mudas"));
            Assert.IsNotNull(actualEleveParClasse.ToList().Find(e => e.Prenom == "Alain"));
        }
    }
}
