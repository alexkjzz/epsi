public static class Program
{
    private static string InviteMenu()
    {
        Console.WriteLine("Choisissez parmis les actions suivantes :");
        Console.WriteLine(" - 1 : action 1");
        Console.WriteLine(" - 2 : action 2");
        Console.WriteLine(" - q : quitter");

        return Console.ReadKey().KeyChar.ToString();
    }

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
                case "2":
                    Action2();
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

        Console.WriteLine();
        Console.WriteLine("Tapez entrer pour revenir au menu...");
        Console.ReadLine();

        Console.Clear();
    }

    public static void Action2()
    {
        Console.Clear();
        Console.WriteLine("---- Action 2 ----");

        //Ici votre code pour l'action 2

        Console.WriteLine();
        Console.WriteLine("Tapez entrer pour revenir au menu...");
        Console.ReadLine();

        Console.Clear();
    }
}