using System;
using System.Linq;

public static class SampleMacro
{
    public static void Print(string title, string deco, int decoRepeat = 1)
    {
        string d = String.Concat(Enumerable.Repeat(deco, decoRepeat));
        Console.WriteLine($"{d} {title} {d}");
    }

    public static void PrintMain(string title)
    {
        Print(title, "@", 4);
    }

    public static void PrintSub(string title)
    {
        Print(title, "#", 4);
    }
}
