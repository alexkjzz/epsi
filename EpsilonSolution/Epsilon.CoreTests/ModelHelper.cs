using Epsilon.Core.Model;

namespace Epsilon.CoreTests
{
    internal static class ModelHelper
    {
        public static Eleve CreateEleve(string nom, params decimal[] notes)
        {
            var eleve = new Eleve()
            {
                Nom = nom
            };
            eleve.Notes.AddRange(notes);
            return eleve;
        }
    }
}