namespace MyVideotheque.Console;

using MyVideotheque.Core.Service;
using System;
using System.Net;
using System.Web;

internal class Program
{
    static void Main(string[] args)
    {
        var cd = new ConsoleDrawing();
        cd.Start();

        string cmd = cd.Ask("Chercher un film : ");

        while (cmd != "q")
        {
            Console.Clear();
            MovieCatalogFinderService f = new MovieCatalogFinderService();

            var lst = f.Search(cmd);

            cd.WriteAt(lst[0].Title, 0, 0);
            cd.AsciiArt(lst[0].Poster);

            cmd = cd.Ask("Chercher un film : ");
        }

    }
}
