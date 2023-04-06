namespace Motus.Core
{

    public class Plateau
    {
        ICalculMotService calculMotService;
        public string MotADeviner { get; set; }

        public List<EssaiMot> Tentatives { get; set; }

        public Plateau(ICalculMotService calculMotService)
        {
            this.calculMotService = calculMotService;
            this.Tentatives = new List<EssaiMot>();
        }


        public List<string> GetMotsPossibles(int longueur = 5)
        {
            return File.ReadAllLines("mots.txt").Where(m => m.Length == longueur).Select(mm => mm.ToUpper()).ToList();
        }

        public bool MotTrouve()
        {
            throw new NotImplementedException();
        }

        public void ChoisiUnMotAUHasard()
        {
            Random random= new Random(DateTime.Now.Millisecond);
            var list = this.GetMotsPossibles();
            this.MotADeviner = list[random.Next(list.Count)];
        }

        public void AddMot(string mot)
        {
            throw new NotImplementedException();
        }
    }
}
