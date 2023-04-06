namespace DBZ.Dojo.Vestiaires
{
    public interface IGuerrier
    {
        /// <summary>
        /// Nom de ton guerrier, sera affiché dans l'arène
        /// </summary>
        /// <example>Son Goku</example>
        /// <example>Vegeta</example>
        string Nom { get; }

        /// <summary>
        /// Renvoie la prochaine action de ton guerrier
        /// Pour faire ton choix, tu as en paramètre la dernière action de ton adversaire
        /// Si tu as besoin de plus d'information, charge à toi de les enregistrer
        /// </summary>
        /// <param name="dernierActionAdversaire"></param>
        /// <returns>La prochaine action de ton guerrier</returns>
        ActionDeCombat ChoixProchaineAction(ActionDeCombat dernierActionAdversaire);
    }
}