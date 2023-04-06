namespace DBZ.Dojo.Vestiaires;

public class MannequinDeFrappe : IGuerrier
{
    public string Nom
    {
        get
        {
            return "Mannequin de frappe";
        }
    }

    public ActionDeCombat ChoixProchaineAction(ActionDeCombat dernierActionAdversaire)
    {
        return ActionDeCombat.Parade;
    }
}