using HelloWord;
using System.Drawing;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("What to search?");
        string searchWord = Console.ReadLine();

        var text = "public static bool RectangleContains(Rectangle rect, Vector2 point) " +
            "{return point.X >= rect.X && point.X <= rect.X + rect.Width && " +
            "point.Y >= rect.Y && point.Y <= rect.Y + rect.Height; }";

        var service = new searchService();

        var result = service.FindWord(text, searchWord);
        Console.WriteLine("Found this:");
        foreach (var word in result)
        {
            Console.WriteLine($"{word}");
        }


        // RC -> RectangleContains method
        // rc -> rect
    }

    public static bool RectangleContains(Rectangle rect, Vector2 point)
    {
        return point.X >= rect.X && point.X <= rect.X + rect.Width &&
            point.Y >= rect.Y && point.Y <= rect.Y + rect.Height;
    }

}