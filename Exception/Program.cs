using System.Runtime.CompilerServices;

public static class Program
{
    private static string InviteMenu()
    {
        Console.WriteLine("Choisissez parmis les actions suivantes :");
        Console.WriteLine(" - 1 : Jouer avec Worker");
        Console.WriteLine(" - q : quitter");

        return Console.ReadKey().KeyChar.ToString();
    }

    private static Worker _worker = new Worker();

    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("--- Bienvenue dans votre vidéothèque ! ---");

        string commande = Program.InviteMenu();
        while (commande !=null && commande.ToLower() != "q")
        {
            switch (commande)
            {
                case "1": ;
                    Action1();
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



    public static void Action1()
    {
        Console.Clear();
        Console.WriteLine("---- Action 1 ----");

        //Ici votre code pour l'action 1
        Console.WriteLine("Entrez un chiffre entre 1 et 10");
        string input = Console.ReadLine();
        int index = int.Parse(input);
        string chaine = _worker.GetElement(index);

        Console.WriteLine(chaine);

        Console.WriteLine();
        Console.WriteLine("Tapez entrer pour revenir au menu...");
        Console.ReadLine();

        Console.Clear();
    }
}