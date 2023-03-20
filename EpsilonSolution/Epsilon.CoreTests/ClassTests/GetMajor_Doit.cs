using Epsilon.Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epsilon.CoreTests.ClassTests
{
    [TestClass]
    public class GetMajor_Doit
    {
        [TestMethod]
        public void RetournerVide_Quand0Eleve()
        {
            Classe classe = new Classe();
            
            var actual = classe.GetMajor();

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void RetournerMajor_QuandPlusieursEleve()
        {
            Classe classe = new Classe();
            classe.Eleves.Add(ModelHelper.CreateEleve("alain", 1, 2, 3));
            classe.Eleves.Add(ModelHelper.CreateEleve("bernard", 15,15,17,18));
            classe.Eleves.Add(ModelHelper.CreateEleve("albert", 12));

            var actual = classe.GetMajor();

            Assert.AreEqual("bernard", actual.Nom);
        }
    }
}
