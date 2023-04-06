namespace Motus.Console;

using Motus.Core;
using System;

public static class Program
{
    public static ConsoleDrawing CD = new ConsoleDrawing();
    public static List<string> MotsValides = new List<string>();
    public static string GRILLE = @" MO-MO-MOTUS
 ╔═══╦═══╦═══╦═══╦═══╗
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╠═══╬═══╬═══╬═══╬═══╣
 ║   ║   ║   ║   ║   ║
 ╚═══╩═══╩═══╩═══╩═══╝
";

    public static void PrintGrille()
    {
        CD.WriteAt(GRILLE, 0, 0);
        CD.WriteAt("JAUNE:", 0, 15, ConsoleColor.Gray, ConsoleColor.DarkYellow);
        CD.WriteAt("Bonne lettre mal placee", 8, 15);
        CD.WriteAt("ROUGE:", 0, 16, ConsoleColor.Gray, ConsoleColor.Red);
        CD.WriteAt("Bonne lettre bien placee", 8, 16);
    }

    public static void Main(string[] args)
    {
        Plateau plateau = new Plateau(new CalculMotService());
        MotsValides = plateau.GetMotsPossibles();

        plateau.ChoisiUnMotAUHasard();

        PrintGrille();

        while (!plateau.MotTrouve() && plateau.Tentatives.Count<6)
        {
            string mot = ReadValidMot("Entrez un mot :", 22);

            plateau.AddMot(mot);

            Console.Clear();
            PrintGrille();

            for (int i=0;i<plateau.Tentatives.Count;i++)
            {
                var essai = plateau.Tentatives[i];
                for(int indexLettre = 0; indexLettre<5; indexLettre++)
                {
                    PrintLettre(essai.Lettres[indexLettre], i, indexLettre);
                }
            }
        }

        if (plateau.MotTrouve())
        {
            CD.Info("GAGNE !!!!");
        }
        else
        {
            CD.Warning($"PERDU !!! le mot était {plateau.MotADeviner}");
        }
    }

    private static void PrintLettre(Lettre lettre, int indexMot, int indexLettre)
    {
        ConsoleColor foregroundColor = ConsoleColor.Gray;
        ConsoleColor backgroundColor = ConsoleColor.Black;

        if (lettre.Etat == EtatLettre.BonneLettreMalPlacee)
        {
            backgroundColor = ConsoleColor.DarkYellow;
        }
        else if (lettre.Etat == EtatLettre.OK)
        {
            backgroundColor = ConsoleColor.Red;
        }

        CD.WriteAt($" {lettre.Caractere} ", 2 + indexLettre * 4, 2 + indexMot * 2, foregroundColor, backgroundColor);
    }

    private static string ReadValidMot(string message, int y)
    {
        CD.WriteAt(message, 0, y);
        string rawAnswer = Console.ReadLine();
        while (!(rawAnswer.Length==5) || !MotsValides.Contains(rawAnswer))
        {
            CD.Warning($"Attention, seul les mots valides de 5 caractères sont admis !", y - 1);
            CD.WriteAt("                                                                   ", 0, y);
            CD.WriteAt(message, 0, y);
            rawAnswer = Console.ReadLine();
        }
        CD.WriteAt("                                                                   ", 0, y-1);
        return rawAnswer;
    }
}
