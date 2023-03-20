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

        public decimal CalculMoyenne()
        {
            throw new NotImplementedException();
        }

    }
}
