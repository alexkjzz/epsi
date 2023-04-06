using DBZ.Dojo.Vestiaires;

namespace DBZ.KameHouse
{
    public class Krillin : IGuerrier
    {
        public string Nom
        {
            get
            {
                return "Krillin";
            }
        }

        private bool _jeSuisCharge;

        public ActionDeCombat ChoixProchaineAction(ActionDeCombat dernierActionAdversaire)
        {
            if (!this._jeSuisCharge)
            {
                this._jeSuisCharge = true;
                return ActionDeCombat.ChargeKameHameHa;
            }

            this._jeSuisCharge = false;
            return ActionDeCombat.KameHameHa;
        }
    }
}