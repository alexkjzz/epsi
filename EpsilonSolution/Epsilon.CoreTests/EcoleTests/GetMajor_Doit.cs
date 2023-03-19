using Epsilon.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epsilon.CoreTests.EcoleTests
{
    internal class GetMajor_Doit
    {
        [TestMethod]
        public void RetournerVide_Quand0Eleve()
        {
            Ecole ecole = new Ecole();
            Classe sn2Dev = new Classe() { Nom = "SN2 Dev" };
            sn2Dev.Eleves.Add(ModelHelper.CreateEleve(""))
            Classe sn2Reseau = new Classe() { Nom = "SN2 Réseau" };

            var actual = classe.GetMajor();

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void RetournerMajor_QuandPlusieursEleve()
        {
            Classe classe = new Classe();
            classe.Eleves.Add(ModelHelper.CreateEleve("alain", 1, 2, 3));
            classe.Eleves.Add(ModelHelper.CreateEleve("bernard", 15, 15, 17, 18));
            classe.Eleves.Add(ModelHelper.CreateEleve("albert", 12));

            var actual = classe.GetMajor();

            Assert.AreEqual("bernard", actual.Nom);
        }
    }
}
}
