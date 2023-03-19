using Epsilon.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epsilon.CoreTests.EcoleTests
{
    [TestClass()]
    public class GetMajor_Doit
    {
        [TestMethod]
        public void RetournerVide_Quand0Eleve()
        {
            Ecole ecole = new Ecole();

            Classe sn2Dev = new Classe() { Nom = "SN2 Dev" };
            ecole.Classes.Add(sn2Dev);

            Classe sn2Reseau = new Classe() { Nom = "SN2 Réseau" };
            ecole.Classes.Add(sn2Reseau);

            var actual = ecole.GetMajor();

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void RetournerMajor_QuandPlusieursEleve()
        {
            Ecole ecole = new Ecole();

            Classe sn2Dev = new Classe();
            ecole.Classes.Add(sn2Dev);
            sn2Dev.Eleves.Add(ModelHelper.CreateEleve("alain", 1, 2, 3));
            sn2Dev.Eleves.Add(ModelHelper.CreateEleve("bernard", 15, 15, 17, 18));
            sn2Dev.Eleves.Add(ModelHelper.CreateEleve("albert", 12));

            Classe sn2Reseau = new Classe() { Nom = "SN2 Réseau" };
            ecole.Classes.Add(sn2Reseau);
            sn2Reseau.Eleves.Add(ModelHelper.CreateEleve("marvin", 0, 1, 2));
            sn2Reseau.Eleves.Add(ModelHelper.CreateEleve("walter", 11, 15, 15));
            sn2Reseau.Eleves.Add(ModelHelper.CreateEleve("seb", 18, 19,20));

            var actual = ecole.GetMajor();

            Assert.AreEqual("seb", actual.Nom);
        }
    }
}

