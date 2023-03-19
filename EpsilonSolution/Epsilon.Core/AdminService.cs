using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epsilon.Core.Model;

namespace Epsilon.Core
{
    public class AdminService
    {
        /// <summary>
        /// Ajoute un élève à l'administration et lui affecte la classe
        /// </summary>
        /// <param name="prenom"></param>
        /// <param name="nom"></param>
        /// <param name="classe">Classe de l'élève</param>
        /// <exception cref="NotImplementedException"></exception>
        public void AjouteEleve(string prenom, string nom, string classe)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie la liste de tous les élèves de la classe en paramètre
        /// </summary>
        /// <param name="classe"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Eleve> ListeEleveParClasse(string classe)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renvoie la liste de toutes les classes du système
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<Classe> ListeClasse()
        {
            throw new NotImplementedException();
        }
    }
}
