namespace Motus.Core
{
    public class EssaiMot
    {
        public EssaiMot() 
        {
            this.Lettres = new List<Lettre>();
        }

        public List<Lettre> Lettres { get; set; }

        public bool IsOk()
        {
            throw new NotImplementedException();
        }
    }
}
