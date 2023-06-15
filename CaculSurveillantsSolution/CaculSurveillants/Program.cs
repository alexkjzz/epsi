public static class Program
{

    private static bool TryParseNombreEtudiant(out int nombre)
    {
        Console.Write("Nombre d'étudiant à surveiller : ");
        var input = Console.ReadLine();
        return int.TryParse(input, out nombre);
    }

    public static void Main()
    {
        Console.WriteLine("*** Calcul du nombde de serveillants pour un examen ***");

        int nombreEtudiant;
        while (!TryParseNombreEtudiant(out nombreEtudiant))
        {
            Console.WriteLine("Veillez entrer un nombre valide !");
        }

        Calculator calculator = new Calculator();
        int nombreSurveillant = calculator.CalculNombreSurveillant(nombreEtudiant);

        Console.WriteLine($"Le nombre de surveillant minimum pour {nombreEtudiant} est : {nombreSurveillant}");
    }
}
