using Epsilon.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epsilon.CoreTests.EcoleTests
{
    [TestClass()]
    internal class AjouteEleve_Doit
    {
        [TestMethod()]
        public void AjouterLEleveALaClasse_QuandLaClasseExisteDeja()
        {
            //Given
            Ecole epsi = new Ecole();
            epsi.Classes.Add(new Classe() { Nom = "SN1" });
            epsi.Classes.First().Eleves.Add(new Eleve() { Nom = "Mudas", Prenom = "Albert" });

            //When
            epsi.AjouteEleve("Alain", "Terrieur", "SN1");

            //Then
            var expectedAlain = epsi.Classes.Find(c => c.Nom == "SN1").Eleves.Find(e => e.Nom == "Terrieur" && e.Prenom == "Alain");
            Assert.IsNotNull(expectedAlain);
        }

        [TestMethod()]
        public void AjouterLEleveEtLaClasse_WhenLaClasseNExistePas()
        {
            //Givin
            Ecole epsi = new Ecole();

            //When
            epsi.AjouteEleve("Alain", "Terrieur", "SN1");

            //Then
            var expectedAlain = epsi.Classes.Find(c => c.Nom == "SN1").Eleves.Find(e => e.Nom == "Terrieur" && e.Prenom == "Alain");
            Assert.IsNotNull(expectedAlain);
        }

    }
}
