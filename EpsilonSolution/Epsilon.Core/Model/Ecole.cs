namespace Epsilon.Core.Model
{
    public class Ecole
    {
        public string Nom { get; set; }

        public List<Classe> Classes { get; set; }

        public Ecole()
        {
            this.Classes = new List<Classe>();
        }

        public void AjouteEleve(string prenom, string nom, string classe)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Eleve> ListeEleveParClasse(string classe)
        {
            throw new NotImplementedException();
        }

        public void AddNote(Eleve eleve, params decimal[] notes)
        {
            throw new NotImplementedException();
        }

        public Eleve GetMajor()
        {
            throw new NotImplementedException();
        }
    }
}
