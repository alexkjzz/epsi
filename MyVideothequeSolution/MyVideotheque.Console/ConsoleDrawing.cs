namespace MyVideotheque.Console;

using System;
using System.Net;
using System.Web;

public class ConsoleDrawing
{
    private int _originRow;
    private int _originCol;

    public void Start()
    {
        Console.Clear();
        // Clear the screen, then save the top and left coordinates.
        _originRow = Console.CursorTop;
        _originCol = Console.CursorLeft;
    }

    public string Ask(string question)
    {
        this.WriteAt(question, 0, Console.WindowHeight-2);
        return Console.ReadLine();
    }

    public void Info(string message)
    {
        this.WriteAt(message, 0, Console.WindowHeight - 4, ConsoleColor.DarkGreen);
    }
    public void Warning(string message)
    {
        this.WriteAt(message, 0, Console.WindowHeight - 6, ConsoleColor.DarkYellow);
    }

    public void WriteAt(string s, int x, int y,
        ConsoleColor foregroundColor = ConsoleColor.Gray, ConsoleColor backgroundColor = ConsoleColor.Black)
    {
        try
        {
            Console.SetCursorPosition(_originCol + x, _originRow + y);
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            Console.Write(s);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.Clear();
            Console.WriteLine(e.Message);
        }
    }

    public void AsciiArt(string urlImage)
    {
        string url = $"https://www.degraeve.com/img2txt-yay.php?url={HttpUtility.UrlEncode(urlImage)}&mode=A&size=20&charstr=ABCDEFGHIJKLMNOPQRSTUVWXYZ&order=O&invert=N&aspect_ratio=1";

        WebClient c = new WebClient();
        var html = c.DownloadString(url);
        int i = html.IndexOf("<pre>") + "<pre>".Length;
        int j = html.IndexOf("</pre>");

        var text = html.Substring(i, j - i);
        var tab = text.Split("\n");

        this.WriteAt(urlImage, 0, 1);
        for (int col = 0; col < tab.Length; col++)
        {
            if (col > 25)
            {
                break;
            }
            this.WriteAt(tab[col], 1, col + 1);
        }

    }

}