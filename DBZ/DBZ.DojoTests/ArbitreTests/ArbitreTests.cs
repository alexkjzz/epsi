using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBZ.Dojo.Exception;
using DBZ.Dojo.Vestiaires;
using Moq;

namespace DBZ.Dojo.Tests
{
    [TestClass()]
    public class Fight_Should
    {
        
        [TestMethod()]
        public void MustCallChoixProchaineAction_Fight()
        {
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Verifiable();
            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Verifiable();

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            arbitre.Fight();

            guerrier1Mock.Verify();
            guerrier2Mock.Verify();
        }


        [TestMethod()]
        public void CallWithSalutation_WhenFirstTour(){
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Verifiable();
            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Verifiable();

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            arbitre.Fight();

            guerrier1Mock.Verify(g => g.ChoixProchaineAction(ActionDeCombat.Salutation));
            guerrier2Mock.Verify(g => g.ChoixProchaineAction(ActionDeCombat.Salutation));
        }

        [TestMethod()]
        public void LastActionRecord_AfterFight()
        {
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.Parade);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            var res = arbitre.Fight();

            Assert.AreEqual(ActionDeCombat.ChargeKameHameHa, res.LastActionGuerrier1);
            Assert.AreEqual(ActionDeCombat.Parade, res.LastActionGuerrier2);
        }

        [TestMethod()]
        public void NotKoIfKameHameHaAndParade_DuringFight()
        {
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.Parade);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            var res = arbitre.Fight();

            Assert.IsFalse(res.KoGuerrier2);
        }
        [TestMethod()]
        public void NotKoIfKameHameHaAndParade_DuringFightMiroir()
        {
            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.Parade);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            var res = arbitre.Fight();

            Assert.IsFalse(res.KoGuerrier1);
        }

        [TestMethod()]
        public void KoIfKameHameHaAndCharge_DuringFight()
        {
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            var res = arbitre.Fight();

            Assert.IsTrue(res.KoGuerrier2);
        }

        [TestMethod()]
        public void KoIfKameHameHaAndCharge_DuringFightMiroir()
        {
            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 1");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            var res = arbitre.Fight();

            Assert.IsTrue(res.KoGuerrier1);
        }

        [TestMethod()]
        public void NotKoIfKameHameHaAndKameHameHa_DuringFight()
        {
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            var res = arbitre.Fight();

            Assert.IsFalse(res.KoGuerrier2);
            Assert.IsFalse(res.KoGuerrier1);
        }

        [TestMethod()]
        public void KoIfKameHameHaAndKameHameHaNonCharge_DuringFight()
        {
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            var res = arbitre.Fight();

            Assert.IsTrue(res.KoGuerrier2);
            Assert.IsFalse(res.KoGuerrier1);
        }

        [TestMethod()]
        public void KoIfKameHameHaAndKameHameHaNonCharge_DuringFightMiroir()
        {
            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            var res = arbitre.Fight();

            Assert.IsFalse(res.KoGuerrier2);
            Assert.IsTrue(res.KoGuerrier1);
        }

        [TestMethod()]
        public void ReturnSuperSaiyan_After5Kamehameha()
        {
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");

            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.Parade);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();

            Assert.IsTrue(arbitre.IsGuerrier1SuperSaiyan);
            Assert.IsFalse(arbitre.IsGuerrier2SuperSaiyan);
        }

        [TestMethod()]
        public void ReturnNotSuperSaiyan_After5KamehamehaNonCharge()
        {
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");

            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.Parade);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();

            Assert.IsFalse(arbitre.IsGuerrier1SuperSaiyan);
            Assert.IsFalse(arbitre.IsGuerrier2SuperSaiyan);
        }

        [TestMethod()]
        public void ReturnSuperSaiyan_After5KamehamehaMiroir()
        {
            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 1");

            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.Parade);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();

            Assert.IsFalse(arbitre.IsGuerrier1SuperSaiyan);
            Assert.IsTrue(arbitre.IsGuerrier2SuperSaiyan);
        }


        [TestMethod()]
        public void SuperSaiyanKameHameHaKoParade_After5Kamehameha()
        {
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");

            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.Parade);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            //-> guerrier 1 Super Saiyan
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            var resultatTour = arbitre.Fight();

            Assert.IsTrue(resultatTour.KoGuerrier2);
            Assert.IsFalse(resultatTour.KoGuerrier1);
        }

        [TestMethod()]
        public void SuperSaiyanKameHameHaKoParade_After5KamehamehaMiroir()
        {
            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");

            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.Parade);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            //-> guerrier 1 Super Saiyan
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            var resultatTour = arbitre.Fight();

            Assert.IsFalse(resultatTour.KoGuerrier2);
            Assert.IsTrue(resultatTour.KoGuerrier1);
        }

        [TestMethod()]
        [ExpectedException(typeof(NezQuiSaigneException))]
        public void MustStop_AfterKo()
        {
            var guerrier1Mock = new Mock<IGuerrier>();
            guerrier1Mock.Setup(g => g.Nom).Returns("fake guerrier 1");
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            var guerrier2Mock = new Mock<IGuerrier>();
            guerrier2Mock.Setup(g => g.Nom).Returns("fake guerrier 2");
            guerrier2Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);

            Arbitre arbitre = new Arbitre(guerrier1Mock.Object, guerrier2Mock.Object);

            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.KameHameHa);
            arbitre.Fight();
            guerrier1Mock.Setup(g => g.ChoixProchaineAction(It.IsAny<ActionDeCombat>())).Returns(ActionDeCombat.ChargeKameHameHa);
            arbitre.Fight();
        }
    }
}