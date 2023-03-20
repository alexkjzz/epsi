using Epsilon.Core;
using Epsilon.Core.Model;

public static class Program
{
    private static EpsiService _epsi = new EpsiService();

    private static string InviteMenu()
    {
        Console.WriteLine("Choisissez parmis les actions suivantes :");
        Console.WriteLine(" - 1 : Ajouter des élèves");
        Console.WriteLine(" - 2 : Lister les élèves par classe");
        Console.WriteLine(" - 3 : Ajouter des notes");
        Console.WriteLine(" - 4 : Afficher le major de l'école");
        Console.WriteLine(" - 5 : Afficher le major d'une classe");
        Console.WriteLine(" - q : quitter");

        return Console.ReadKey().KeyChar.ToString();
    }

    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("--- Bienvenue dans votre service administratif ! ---");

        string commande = Program.InviteMenu();
        while (commande != null && commande.ToLower() != "q")
        {
            switch (commande)
            {
                case "1":
                    AjouterEleve();
                    break;
                case "2":
                    ListerEleveParClasse();
                    break;
                case "3":
                    AjoutNote();
                    break;
                case "4":
                    MajorEcole();
                    break;
                case "5":
                    MajorClasse();
                    break;
                default:
                    Console.WriteLine($"Commande {commande} inconnue !");
                    break;
            }

            commande = Program.InviteMenu();
        }

        Console.Clear();
        Console.WriteLine("Bye !");
    }

    private static void AjouterEleve()
    {
        Console.Clear();
        Console.WriteLine("---- Ajouter des élèves ----");

        Console.Write("Prénom: ");
        var prenom = Console.ReadLine();
        Console.Write("Nom: ");
        var nom = Console.ReadLine();
        Console.Write("Classe: ");
        var classe = Console.ReadLine();

        _epsi.AjouteEleve(prenom, nom, classe);

        Console.Clear();
    }

    public static void ListerEleveParClasse()
    {
        Console.Clear();
        Console.WriteLine("---- Lister les élèves par classe ----");

        foreach(var classe in _epsi.Classes)
        {
            Console.WriteLine($"- {classe.Nom} -");
            foreach(var eleve in classe.Eleves)
            {
                Console.WriteLine($" * {eleve.Prenom} {eleve.Nom} : {eleve.CalculMoyenne()}");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Tapez entrer pour revenir au menu...");
        Console.ReadLine();

        Console.Clear();
    }

    public static void AjoutNote()
    {
        Console.Clear();
        Console.WriteLine("---- Ajouter des élèves ----");

        Console.Write("Prénom: ");
        var prenom = Console.ReadLine();
        Console.Write("Nom: ");
        var nom = Console.ReadLine();
        Console.Write("Notes (séparés par des espaces) : ");
        string notes = Console.ReadLine(); //chaîne du type "12 15 16.5 17"

        // "12 15 16.5 17" => ["12", "15", "16.5", "17"]
        var tableauStringNotes = notes.Split(" ");
        //["12", "15", "16.5", "17"] => [12, 15, 16.5, 17]
        var tableauDecimalNotes = tableauStringNotes.Select(Convert.ToDecimal);

        var tousLesEleves = _epsi.Classes.SelectMany(c => c.Eleves);
        var elevePourAjoutNote = tousLesEleves.ToList().Find(eleve => eleve.Prenom == prenom && eleve.Nom == nom);

        _epsi.AddNote(elevePourAjoutNote, tableauDecimalNotes.ToArray());

        Console.Clear();
    }

    public static void MajorEcole()
    {
        Console.Clear();
        Console.WriteLine("---- Major de l'école ----");

        Console.WriteLine();
        var major = _epsi.GetMajor();
        Console.WriteLine($"Le major de l'école est : {major.Prenom} {major.Nom} : {major.CalculMoyenne()}");

        Console.WriteLine();
        Console.WriteLine("Tapez entrer pour revenir au menu...");
        Console.ReadLine();

        Console.Clear();
    }
    public static void MajorClasse()
    {
        Console.Clear();
        Console.WriteLine("---- Major de classe ----");

        Console.Write("Classe: ");
        var nomClasse = Console.ReadLine();

        Classe classe = _epsi.Classes.Find(c => c.Nom == nomClasse);
        if (classe == null) 
        {
            Console.WriteLine($"La classe {nomClasse} n'existe pas !");
        }

        Console.WriteLine();
        var major = classe.GetMajor();
        Console.WriteLine($"Le major de la classe {classe.Nom} est : {major.Prenom} {major.Nom} : {major.CalculMoyenne()}");

        Console.WriteLine();
        Console.WriteLine("Tapez entrer pour revenir au menu...");
        Console.ReadLine();

        Console.Clear();
    }
}