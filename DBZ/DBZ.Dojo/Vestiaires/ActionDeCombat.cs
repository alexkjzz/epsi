namespace DBZ.Dojo.Vestiaires;

public enum ActionDeCombat
{
    /// <summary>
    /// Première action avant le combat
    /// </summary>
    /// <remarks>déconseillé lors du combat !</remarks>
    Salutation,
    /// <summary>
    /// Permet de te protéger d'une attaque
    /// </summary>
    Parade,
    /// <summary>
    /// Obligatoire avant de pouvoir attaquer, attention tu es vulnérable !
    /// </summary>
    ChargeKameHameHa,
    /// <summary>
    /// Attaque, mais attention tu dois avoir chargé avant !
    /// Peut être paré par <see cref="Parade"/>
    /// </summary>
    /// <remarks>Au bout de 5 KameHameHa, tu deviens Super Saiyan et ton KameHameHa ne peut plus être paré !</remarks>
    KameHameHa
}