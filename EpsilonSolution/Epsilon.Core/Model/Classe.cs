namespace Epsilon.Core.Model
{
    public class Classe
    {
        public string Nom { get; set; }
        public List<Eleve> Eleves { get; set; }

        public Classe()
        {
            this.Eleves = new List<Eleve>();
        }

        public Eleve GetMajor()
        {
            throw new NotImplementedException();
        }
    }
}
