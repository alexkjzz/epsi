using Epsilon.Core.Model;

namespace Epsilon.Core
{
    public class EpsiService
    {
        private Ecole _epsi;

        public EpsiService()
        {
            this._epsi = new Ecole()
            {
                Nom = "EPSI"
            };
        }

        public List<Classe> Classes { get; set; }

        public void AjouteEleve(string prenom, string nom, string classe)
        {
            this._epsi.AjouteEleve(prenom, nom, classe);
        }

        public IEnumerable<Eleve> ListeEleveParClasse(string classe)
        {
            return this._epsi.ListeEleveParClasse(classe);
        }

        public void AddNote(Eleve eleve, params decimal[] notes)
        {
            this._epsi.AddNote(eleve, notes);
        }

        public Eleve GetMajor()
        {
            return this._epsi.GetMajor();
        }
    }

}
