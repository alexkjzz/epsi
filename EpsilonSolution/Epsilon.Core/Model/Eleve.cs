namespace Epsilon.Core.Model
{
    public class Eleve
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public List<Decimal> Notes { get; set; }

        public void AjouterNotes(params decimal[] notes)
        {
            throw new NotImplementedException();
        }

        public Eleve()
        {
            this.Notes = new List<Decimal>();
        }

        public decimal CalculMoyenne()
        {
            if (this.Notes.Count() == 0)
            {
                return 0;
            }
            throw new NotImplementedException();
        }

    }
}
