using Motus.Core;

namespace Motus.CoreTests
{
    public static class TestHelper
    {
        public static EssaiMot CreateValidMot(string chaine)
        {
            EssaiMot mot = new EssaiMot();
            foreach (char c in chaine)
            {
                mot.Lettres.Add(new Lettre() { Caractere = c, Etat = EtatLettre.OK });
            }
            return mot;
        }
        public static EssaiMot CreateInvalidMot(string chaine)
        {
            EssaiMot mot = new EssaiMot();
            foreach (char c in chaine)
            {
                mot.Lettres.Add(new Lettre() { Caractere = c, Etat = EtatLettre.OK });
            }
            mot.Lettres[0].Etat= EtatLettre.MauvaiseLettre;
            return mot;
        }
    }
}
