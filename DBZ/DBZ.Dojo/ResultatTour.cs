using DBZ.Dojo.Vestiaires;

namespace DBZ.Dojo;

public class ResultatTour
{
    public string Description { get; set; }
    public ActionDeCombat LastActionGuerrier1 { get; set; }
    public ActionDeCombat LastActionGuerrier2 { get; set; }
    public bool KoGuerrier1 { get; set; }
    public bool KoGuerrier2 { get; set; }

    public ResultatTour()
    {

    }
    public ResultatTour(ResultatTour resultat)
    {
        this.LastActionGuerrier1 = resultat.LastActionGuerrier1;
        this.LastActionGuerrier2 = resultat.LastActionGuerrier2;
    }
}