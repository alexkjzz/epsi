using System.Runtime.CompilerServices;
using DBZ.Dojo;
using DBZ.Dojo.Vestiaires;
using DBZ.KameHouse;

namespace DBZ.Arena;

public static class ProgramArena
{
    private static ConsoleDrawing CD;

    private static void LoadGuerriers()
    {
        Krillin b = new Krillin();

        var ass = AppDomain.CurrentDomain.GetAssemblies();

        var typeIGuerrier = typeof(IGuerrier);
        var tousLesTypesDeGuerriersDisponibles = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => typeIGuerrier.IsAssignableFrom(p) && !p.IsInterface).ToList();


        int nbGuerrier = tousLesTypesDeGuerriersDisponibles.Count();
        _guerriers = new List<IGuerrier>();

        for (int i = 0; i < nbGuerrier; i++)
        {
            var typeGuerrier = tousLesTypesDeGuerriersDisponibles[i];
            IGuerrier guerrier = (IGuerrier)Activator.CreateInstance(typeGuerrier);
            _guerriers.Add(guerrier);
        }
    }

    static List<IGuerrier> _guerriers = new List<IGuerrier>();

    private static Arbitre SelectGuerriers()
    {
        CD.WriteAt("Choisissez les adversaires !", 0, 0);
        CD.WriteAt("--------------------------------------", 0, 1);

        int nbGuerrier = _guerriers.Count;
        for (int i = 0; i < nbGuerrier; i++)
        {
            int x = 0;
            int y = i + 3;
            if (i >= 10)
            {
                x = 40;
                y = 3 + i - 10;
            }

            CD.WriteAt($"{i}. {_guerriers[i].Nom}", x, y);
        }

        int indiceGuerrier1 = ReadValidInt("Entrer le numéro de l'adversaire 1 :", 13, 0, nbGuerrier - 1);
        var guerrier1 = _guerriers[indiceGuerrier1];
        CD.WriteAt($"Choisissez l'adversaire de {guerrier1.Nom}", 0, 0);
        CD.WriteAt("         ", 36, 13);
        int indiceGuerrier2 = ReadValidInt("Entrer le numéro de l'adversaire 2 :", 13, 0, nbGuerrier - 1);
        var guerrier2 = _guerriers[indiceGuerrier2];

        return new Arbitre(guerrier1, guerrier2);
    }

    public static void Main(string[] args)
    {
        CD = new ConsoleDrawing();
        CD.Start();

        LoadGuerriers();

        string userInput = string.Empty;
        do
        {
            Console.Clear();

            Arbitre arbitre = SelectGuerriers();

            Console.Clear();

            CD.WriteAt(arbitre.Presentation(), 0, 2);

            Thread.Sleep(2000);

            List<ResultatTour> tours = new List<ResultatTour>();
            int tour = 1;
            var resultatTour = arbitre.Fight();
            tours.Add(resultatTour);
            int index = 0;
            while (!resultatTour.IsFinished())
            {
                Console.Clear();

                CD.WriteAt($"Combat entre {arbitre.Guerrier1.Nom} et {arbitre.Guerrier2.Nom} [{tour}]", 0, 0);

                index = 0;
                for (int i = tours.Count - 1; i >= 0; i--)
                {
                    CD.WriteAt($"{i}  {tours[i].Description}", 0, 2 + index);
                    index++;
                    if (index > 10)
                    {
                        break;
                    }
                }

                Thread.Sleep(500);
                resultatTour = arbitre.Fight();
                tours.Add(resultatTour);
                tour++;
            }


            Console.Clear();

            CD.WriteAt(arbitre.Resultat(), 0, 0);

            index = 0;
            for (int i = tours.Count - 1; i >= 0; i--)
            {
                CD.WriteAt($"{i.ToString().PadRight(3,' ')}  {tours[i].Description}", 0, 2 + index);
                index++;
                if (index > 10)
                {
                    break;
                }
            }

            CD.WriteAt($"Tapez entrer pour un nouveau combat, 'q' pour quitter !", 0, 25);
            userInput = Console.ReadLine();
        } while (userInput.ToLower() != "q");

    }

    public static bool IsFinished(this ResultatTour res)
    {
        return res.KoGuerrier1 || res.KoGuerrier2;
    }
    

    private static int ReadValidInt(string message, int y, int min, int max)
    {
        CD.WriteAt(message, 0, y);
        int answer = -1;
        string rawAnswer = Console.ReadLine();
        while (!int.TryParse(rawAnswer, out answer) || answer < min || answer > max)
        {
            CD.Warning($"Attention, chiffre de {min} à {max} attendu ! ", y - 1);
            CD.WriteAt(message, 0, y);
            rawAnswer = Console.ReadLine();
        }
        return answer;
    }
}