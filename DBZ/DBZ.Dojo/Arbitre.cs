using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBZ.Dojo.Exception;
using DBZ.Dojo.Vestiaires;

namespace DBZ.Dojo
{
    public class Arbitre
    {
        public IGuerrier Guerrier1 { get; set; }
        public IGuerrier Guerrier2 { get; set; }

        public bool IsGuerrier1SuperSaiyan { get; private set; }
        public bool IsGuerrier2SuperSaiyan { get; private set; }

        public ResultatTour LastResultat { get; set; }

        public Arbitre(IGuerrier guerrier1, IGuerrier guerrier2)
        {
            if (guerrier1 == null || guerrier2 == null)
            {
                throw new NezQuiSaigneException("Il faut 2 guerriers pour un combat !");
            }
            if (guerrier1.Nom == guerrier2.Nom)
            {
                throw new NezQuiSaigneException("Les 2 combattants ne peuvent avoir le même nom !");
            }
            this.Guerrier1 = guerrier1;
            this.Guerrier2 = guerrier2;
        }

        public string Presentation()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Veillez accueillir notre premier combattant {this.Guerrier1.Nom} !");
            sb.AppendLine($"Veillez accueillir notre second combattant {this.Guerrier2.Nom} !");
            sb.AppendLine($"Que le meilleur gagne !");

            return sb.ToString();
        }

        private bool _isGuerrier1Charge;
        private bool _isGuerrier2Charge;

        private int _nbKameHameHaGuerrier1;
        private int _nbKameHameHaGuerrier2;

        private bool CalculKoGuerrier(ActionDeCombat action, bool isCharge, bool isSuperSaiyan, ActionDeCombat actionAdversaire, bool isAdversaireCharge, bool isAdversaireSuperSaiyan)
        {
            if (action == ActionDeCombat.KameHameHa && actionAdversaire == ActionDeCombat.KameHameHa && isCharge && isAdversaireCharge)
            {
                if (!isSuperSaiyan && isAdversaireSuperSaiyan)
                {
                    return true;
                }

                return false;
            }

            return (actionAdversaire == ActionDeCombat.KameHameHa && isAdversaireCharge &&
                    (action != ActionDeCombat.Parade || isAdversaireSuperSaiyan));

        }

        /// <summary>
        /// Combat au tour à tour
        /// </summary>
        /// <returns></returns>
        public ResultatTour Fight()
        {
            if (this.LastResultat != null && (this.LastResultat.KoGuerrier1 || this.LastResultat.KoGuerrier2))
            {
                throw new NezQuiSaigneException("Stoooop ! Un guerrier est KO on arrête de se battre !");
            }
            if (this.LastResultat == null)
            {
                this.LastResultat = new ResultatTour()
                {
                    LastActionGuerrier1 = ActionDeCombat.Salutation,
                    LastActionGuerrier2 = ActionDeCombat.Salutation
                };
            }
            else
            {
                this.LastResultat = new ResultatTour(this.LastResultat);
            }

            var action1 = this.Guerrier1.ChoixProchaineAction(this.LastResultat.LastActionGuerrier2);
            var action2 = this.Guerrier2.ChoixProchaineAction(this.LastResultat.LastActionGuerrier1);

            this.LastResultat.KoGuerrier1 = CalculKoGuerrier(action1, this._isGuerrier1Charge, this.IsGuerrier1SuperSaiyan, action2,
                this._isGuerrier2Charge, this.IsGuerrier2SuperSaiyan);
            this.LastResultat.KoGuerrier2 = CalculKoGuerrier(action2, this._isGuerrier2Charge, this.IsGuerrier2SuperSaiyan, action1,
                this._isGuerrier1Charge, this.IsGuerrier1SuperSaiyan);

            //Pour ne pas être décrit comme SuperSaiyan un tour trop tôt !
            var nom1 = this.Guerrier1.GetNom(this);
            var nom2 = this.Guerrier2.GetNom(this);

            string descKameHameHa1 = "     ";
            string descKameHameHa2 = "     ";
            if (action1 == ActionDeCombat.ChargeKameHameHa)
            {
                this._isGuerrier1Charge = true;
            }
            if (action2 == ActionDeCombat.ChargeKameHameHa)
            {
                this._isGuerrier2Charge = true;
            }
            if (action1 == ActionDeCombat.KameHameHa)
            {
                if (this._isGuerrier1Charge)
                {
                    descKameHameHa1 = "¤¤¤¤¤";
                    this._nbKameHameHaGuerrier1++;
                    if (this._nbKameHameHaGuerrier1 >= 5)
                    {
                        this.IsGuerrier1SuperSaiyan = true;
                        if (this._nbKameHameHaGuerrier1 > 5)
                        {
                            descKameHameHa1 = "@@@@@";
                        }
                    }
                }
                this._isGuerrier1Charge = false;
            }
            if (action2 == ActionDeCombat.KameHameHa)
            {
                if (this._isGuerrier2Charge)
                {
                    descKameHameHa2 = "¤¤¤¤¤";
                    this._nbKameHameHaGuerrier2++;
                    if (this._nbKameHameHaGuerrier2 >= 5)
                    {
                        this.IsGuerrier2SuperSaiyan = true;
                        if (this._nbKameHameHaGuerrier2 > 5)
                        {
                            descKameHameHa2 = "@@@@@";
                        }
                    }
                }
                this._isGuerrier2Charge = false;
            }

            this.LastResultat.LastActionGuerrier1 = action1;
            this.LastResultat.LastActionGuerrier2 = action2;

            this.LastResultat.Description =
                $"[{nom1}] {this.LastResultat.LastActionGuerrier1.GetPrintableAction()} {descKameHameHa1} //  {descKameHameHa2}  {this.LastResultat.LastActionGuerrier2.GetPrintableAction()} [{nom2}] ";

            return this.LastResultat;
        }


        


        public string Resultat()
        {
            if (this.LastResultat == null)
            {
                throw new NezQuiSaigneException("Le combat n'as pas encore commencé !");
            }

            if (!this.LastResultat.KoGuerrier1 && !this.LastResultat.KoGuerrier2)
            {
                throw new NezQuiSaigneException("Le combat n'est pas encore fini !");
            }

            if (this.LastResultat.KoGuerrier1 && this.LastResultat.KoGuerrier2)
            {
                return $"Bouh !!!! {this.Guerrier1.Nom} et {this.Guerrier2.Nom} se sont mis KO tous les deux !";
            }
            var gagnant = (this.LastResultat.KoGuerrier1) ? this.Guerrier2 : this.Guerrier1;
            return $"BRAVO {gagnant.Nom} tu as gagné !!!!";
        }
    }
}
