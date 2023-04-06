using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBZ.Dojo.Vestiaires;

namespace DBZ.Dojo
{
    public static class DBZExtension
    {


        public static string GetNom(this IGuerrier guerrier, Arbitre arbitre)
        {
            string name = guerrier.Nom;
            if (name.Length > 30)
            {
                name = name.Substring(0, 27) + "...";
            }

            if (arbitre.Guerrier1 == guerrier && arbitre.IsGuerrier1SuperSaiyan ||
                arbitre.Guerrier2 == guerrier && arbitre.IsGuerrier2SuperSaiyan)
            {
                name = $"***{name}***";
            }
            else
            {
                name = $"   {name}   ";
            }

            return name;
        }

        public static string GetPrintableAction(this ActionDeCombat action)
        {
            switch (action)
            {
                case ActionDeCombat.ChargeKameHameHa:
                    return "x('_')x";
                    break;
                case ActionDeCombat.KameHameHa:
                    return "X('O')X";
                    break;
                case ActionDeCombat.Parade:
                    return "$(-_-)$";
                    break;
                default:
                    return "('-')";
                    break;
            }
        }
    }
}
