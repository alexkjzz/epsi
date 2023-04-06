namespace Motus.Console;

using System;

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
        this.WriteAt(question, 0, Console.WindowHeight - 2);
        return Console.ReadLine();
    }

    public void Info(string message)
    {
        this.WriteAt(message, 0, 27, ConsoleColor.DarkGreen);
    }

    public void Warning(string message, int y)
    {
        this.WriteAt(message, 0, y, ConsoleColor.DarkYellow);
    }
    public void Warning(string message)
    {
        this.Warning(message, 27);
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

}