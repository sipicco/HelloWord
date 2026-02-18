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

        string sampleText = "RC Rc rc RCSystem ARC_RAIDERS CR ReallyCoolStuff really_cool_stuff ReallyBadStuff really_bad_stuff";

        var service = new searchService();

        var wordScoreDict = service.FindWord(text, searchWord);

        Console.WriteLine("Found this:");
        foreach (var (word, score) in wordScoreDict)
        {
            Console.WriteLine($"""
        '{word}' with Total score: {score.TotScore}
        --- Length score: {score.LengthScore}
        --- Casing score: {score.CasingScore}
        --- Order score: {score.OrderScore}
        
        """);
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